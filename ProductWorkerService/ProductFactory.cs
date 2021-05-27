using Google.Protobuf.WellKnownTypes;
using ProductGrpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWorkerService
{
    public class ProductFactory
    {
        public Task<AddProductRequest> Generate()
        {
            var productName = $"Prod + {DateTimeOffset.UtcNow}";
            var productRequest = new AddProductRequest
            {
                Product = new ProductModel
                {
                    Name = productName,
                    Description = $"{productName}_desc",
                    Price = new Random().Next(1000),
                    Status = ProductStatus.Instock,
                    CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            };
            return Task.FromResult(productRequest);
        }
    }
   
}
