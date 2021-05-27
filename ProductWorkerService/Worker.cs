using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductGrpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;
        private readonly ProductFactory _productFactory;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, ProductFactory productFactory)
        {
            _logger = logger;
            _config = configuration;
            _productFactory = productFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using var channel = GrpcChannel.ForAddress(_config.GetValue<string>("WorkerService:ServerUrl"));
                var client = new ProductProtoService.ProductProtoServiceClient(channel);

                _logger.LogInformation("Add started");

                var addProductResponse = await client.AddProductAsync(await _productFactory.Generate());

                _logger.LogInformation(addProductResponse.ToString());

                await Task.Delay(_config.GetValue<int>("WorkerService:TaskInterval"), stoppingToken);
            }
        }
    }
}
