using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductGrpc.Protos;
using ShoppingCartGrpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingCartWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Thread.Sleep(2000);
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scChannel = GrpcChannel.ForAddress("https://localhost:5002");

                var scClient = new ShoppingCartProtoService.ShoppingCartProtoServiceClient(scChannel);

                var scModel = await GetOrCreateShoppingCartAsync(scClient);


                using var scClientStream = scClient.AddItemIntoShoppingCart();

                var productChannel = GrpcChannel.ForAddress("https://localhost:5001");
                var productClient = new ProductProtoService.ProductProtoServiceClient(productChannel);

                using var clientData = productClient.GetAllProducts(new GetAllProductsRequest());
                await foreach (var responseData in clientData.ResponseStream.ReadAllAsync())
                {
                    _logger.LogInformation(responseData.ToString());
                    var addNewScItem = new AddItemIntoShoppingCartRequest
                    {
                        Username = "sw",
                        DiscountCode = "CODE_100",
                        NewCartItem = new ShoppingCartItemModel
                        {
                            ProductId = responseData.ProductId,
                            Productname = responseData.Name,
                            Price = responseData.Price,
                            Color = "Black",
                            Quantity = 1
                        }
                    };
                   await scClientStream.RequestStream.WriteAsync(addNewScItem);
                    _logger.LogInformation("ShoppingCart Client Stream Added New Item : {addNewScItem}", addNewScItem);
                }

                await scClientStream.RequestStream.CompleteAsync();
                var addItemIntoShoppingCartResponse = await scClientStream;
                _logger.LogInformation("AddItemIntoShoppingCart Client Stream Response: {addItemIntoShoppingCartResponse}", addItemIntoShoppingCartResponse);

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task<ShoppingCartModel> GetOrCreateShoppingCartAsync(ShoppingCartProtoService.ShoppingCartProtoServiceClient scClient)
        {
            ShoppingCartModel shoppingCartModel;
            try
            {
                _logger.LogInformation("GetShoppingCartAsync started..");

                

                shoppingCartModel = await scClient.GetShoppingCartAsync(new GetShoppingCartRequest { Username = "sw" });

                _logger.LogInformation("GetShoppingCartAsync Response: {shoppingCartModel}", shoppingCartModel);
            }
            catch (RpcException exception)
            {
                if (exception.StatusCode == StatusCode.NotFound)
                {
                    _logger.LogInformation("CreateShoppingCartAsync started..");
                    shoppingCartModel = await scClient.CreateShoppingCartAsync(new ShoppingCartModel { Username = "sw" });
                    _logger.LogInformation("CreateShoppingCartAsync Response: {shoppingCartModel}", shoppingCartModel);
                }
                else
                {
                    throw exception;
                }
            }

            return shoppingCartModel;
        }
    }
}
