using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using ProductGrpc.Protos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductGrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Thread.Sleep(2000);
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductProtoService.ProductProtoServiceClient(channel);

            await GetProductAsync(client);
            await GetAllProducts(client);
            await AddProductAsync(client);
            await UpdateProductAsync(client);
            await DeleteProductAsync(client);
            await InsertBulkAsync(client);
            await GetAllProducts(client);


            Console.ReadLine();
        }

        private static async Task InsertBulkAsync(ProductProtoService.ProductProtoServiceClient client)
        {
            using var clientBulk = client.InsertBulkProduct();

            for (int i = 0; i < 9; i++)
            {
                var productModel = new ProductModel
                {
                    Name = $"Product{i+1}",
                    Description = "bulk",
                    Price = 000,
                    Status = ProductStatus.Instock,
                    CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)

                };
                await clientBulk.RequestStream.WriteAsync(productModel);
            }
            await clientBulk.RequestStream.CompleteAsync();

            var responseBulk = await clientBulk;
            Console.WriteLine(responseBulk.Success.ToString(), responseBulk.InsertCount.ToString());

        }

        private static async Task DeleteProductAsync(ProductProtoService.ProductProtoServiceClient client)
        {
            var deleteProductResponse = await client.DeleteProductAsync(new DeleteProductRequest
            {
                ProductId = 2
            });
            Console.WriteLine(deleteProductResponse.Success.ToString());
        }

        private static async Task UpdateProductAsync(ProductProtoService.ProductProtoServiceClient client)
        {
            var updateProductResponse = await client.UpdateProductAsync(

                new UpdateProductRequest
                {
                    Product = new ProductModel
                    {
                        ProductId = 1,
                        Name = "Dupa",
                        Description = "dupa",
                        Price = 000,
                        Status = ProductStatus.Instock,
                        CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)


                    }

                });

             Console.WriteLine(updateProductResponse.ToString());

        }

        private static async Task AddProductAsync(ProductProtoService.ProductProtoServiceClient client)
        {
            var addProductResponse = await client.AddProductAsync(
                new AddProductRequest
                {
                    Product = new ProductModel
                    {
                        Name = "Red",
                        Description = "Red",
                        Price = 599,
                        Status = ProductStatus.Instock,
                        CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)


                    }
                });
            Console.WriteLine(addProductResponse.ToString());
        }

        private static async Task GetAllProducts(ProductProtoService.ProductProtoServiceClient client)
        {
            using var clientData = client.GetAllProducts(new GetAllProductsRequest());
            await foreach (var responseData in clientData.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine(responseData);
            }
        }

        private static async Task GetProductAsync(ProductProtoService.ProductProtoServiceClient client)
        {
            var response = await client.GetProductAsync(new GetProductRequest
            {
                ProductId = 1
            });
            Console.WriteLine(response.ToString());
        }
    }
}
