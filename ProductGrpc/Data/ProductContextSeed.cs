using ProductGrpc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductGrpc.Data
{
    public class ProductContextSeed
    {
        public static void SeedAsync(ProductContext productContext)
        {
            if(!productContext.Product.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        ProductId =1,
                        Name = "P40",
                        Description = "X",
                        Price = 999,
                        Status = ProductStatus.INSTOCK,
                        CreatedTime = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductId =2,
                        Name = "P20",
                        Description = "XX",
                        Price = 100,
                        Status = ProductStatus.INSTOCK,
                        CreatedTime = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductId =3,
                        Name = "P60",
                        Description = "XXX",
                        Price = 567,
                        Status = ProductStatus.INSTOCK,
                        CreatedTime = DateTime.UtcNow
                    },
                };
                productContext.Product.AddRange(products);
                productContext.SaveChanges();
            }
        }
    }
}
