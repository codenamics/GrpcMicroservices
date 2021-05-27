using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductGrpc.Data;
using ProductGrpc.Models;
using ProductGrpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductGrpc.Services
{
    public class ProductService : ProductProtoService.ProductProtoServiceBase
    {
        private readonly IMapper _mapper;
        private readonly ProductContext _productContext;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IMapper mapper,ProductContext productContext, ILogger<ProductService> logger)
        {
            _mapper = mapper;
            _productContext = productContext;
            _logger = logger;
        }

        public override Task<Empty> Test(Empty request, ServerCallContext context)
        {
            return base.Test(request, context);
        }

        public override async Task<ProductModel> GetProduct(GetProductRequest request, ServerCallContext context)
        {
            var product = await _productContext.Product.FindAsync(request.ProductId);

            if(product == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, 
                    $"Product not found"));
            }
            
            var productModel = _mapper.Map<ProductModel>(product);

            return productModel;
        }

        public override async Task GetAllProducts(GetAllProductsRequest request, IServerStreamWriter<ProductModel> responseStream, ServerCallContext context)
        {
            var productList = await _productContext.Product.ToListAsync();

            foreach(var product in productList)
            {
               
                var productModel = _mapper.Map<ProductModel>(product);

                await responseStream.WriteAsync(productModel);
            }
        }

        public override async Task<ProductModel> AddProduct(AddProductRequest request, ServerCallContext context)
        {
            var product = _mapper.Map<Product>(request.Product);
          

            _productContext.Product.Add(product);
            await _productContext.SaveChangesAsync();

            
            var productModel = _mapper.Map<ProductModel>(product);

            return productModel;
        }

        public override async Task<ProductModel> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
        {
            var product = _mapper.Map<Product>(request.Product);

            bool isExist = await _productContext.Product.AnyAsync(p => p.ProductId == product.ProductId);
            if(!isExist)
            {
                throw new RpcException(new Status(StatusCode.NotFound,
                  $"Product not found"));
            }
            _productContext.Entry(product).State = EntityState.Modified;
            try
            {
                await _productContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }

            var productModel = _mapper.Map<ProductModel>(product);
            return productModel;

        }
        public override async Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
        {
            
            var product = await _productContext.Product.FindAsync(request.ProductId);
            if (product != null)
            {
                 _productContext.Product.Remove(product);
            }
            else
            {
                throw new RpcException(new Status(StatusCode.NotFound,
                  $"Product not found"));
            }


            return new DeleteProductResponse
            {
                Success = await _productContext.SaveChangesAsync() > 0
            };
        }
        public override async Task<InsertBulkProductResponse> InsertBulkProduct(IAsyncStreamReader<ProductModel> requestStream, ServerCallContext context)
        {
            while(await requestStream.MoveNext())
            {
                var product = _mapper.Map<Product>(requestStream.Current);
                _productContext.Product.Add(product);

            }
            var insertCount = await _productContext.SaveChangesAsync();

            var response = new InsertBulkProductResponse
            {
                Success = insertCount > 0,
                InsertCount = insertCount
            };
            return response;

        }

    }
}
