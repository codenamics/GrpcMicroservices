using AutoMapper;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingCartGrpc.Data;
using ShoppingCartGrpc.Models;
using ShoppingCartGrpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartGrpc.Services
{
    public class ShoppingCartService : ShoppingCartProtoService.ShoppingCartProtoServiceBase
    {
        private readonly DiscountService _discountService;
        private readonly ShoppingCartContext _shoppingCartContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ShoppingCartService> _logger;

        public ShoppingCartService(DiscountService discountService, ShoppingCartContext shoppingCartContext, IMapper mapper, ILogger<ShoppingCartService> logger)
        {
            _discountService = discountService;
            _shoppingCartContext = shoppingCartContext;
            _mapper = mapper;
            _logger = logger;
        }
        public override async Task<ShoppingCartModel> GetShoppingCart(GetShoppingCartRequest request, ServerCallContext context)
        {
            var shoppingCart = await _shoppingCartContext.ShoppingCart.FirstOrDefaultAsync(s => s.UserName == request.Username);
            if (shoppingCart == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"ShoppingCart with UserName={request.Username} is not found."));
            }

            var shoppingCartModel = _mapper.Map<ShoppingCartModel>(shoppingCart);
            return shoppingCartModel;
        }
        public override async Task<ShoppingCartModel> CreateShoppingCart(ShoppingCartModel request, ServerCallContext context)
        {
            var shoppingCart = _mapper.Map<ShoppingCart>(request);

            var isExist = await _shoppingCartContext.ShoppingCart.AnyAsync(s => s.UserName == shoppingCart.UserName);
            if (isExist)
            {
      
                throw new RpcException(new Status(StatusCode.NotFound, $"ShoppingCart with UserName={request.Username} is already exist."));
            }

            _shoppingCartContext.ShoppingCart.Add(shoppingCart);
            await _shoppingCartContext.SaveChangesAsync();

       

            var shoppingCartModel = _mapper.Map<ShoppingCartModel>(shoppingCart);
            return shoppingCartModel;
        }
        public override async Task<RemoveItemIntoShoppingCartResponse> RemoveItemIntoShoppingCart(RemoveItemIntoShoppingCartRequest request, ServerCallContext context)
        {
            var shoppingCart = await _shoppingCartContext.ShoppingCart.FirstOrDefaultAsync(s => s.UserName == request.Username);

            if (shoppingCart == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "NotFound"));
            }

            var removeCartItem = shoppingCart.Items.FirstOrDefault(i => i.ProductId == request.RemoveCartItem.ProductId);
            if (removeCartItem == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "NotFound"));
            }

            shoppingCart.Items.Remove(removeCartItem);

            var removeCount = await _shoppingCartContext.SaveChangesAsync();

            var response = new RemoveItemIntoShoppingCartResponse
            {
                Success = removeCount > 0
            };
            return response;

        }
        public override async Task<AddItemIntoShoppingCartResponse> AddItemIntoShoppingCart(IAsyncStreamReader<AddItemIntoShoppingCartRequest> requestStream, ServerCallContext context)
        {
            while(await requestStream.MoveNext())
            {
                var shoppingCart = await _shoppingCartContext.ShoppingCart.FirstOrDefaultAsync(s => s.UserName == requestStream.Current.Username);

                if (shoppingCart == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "NotFound"));
                }

                var newAddedCartItem = _mapper.Map<ShoppingCartItem>(requestStream.Current.NewCartItem);
                var cartItem = shoppingCart.Items.FirstOrDefault(i => i.ProductId == newAddedCartItem.ProductId);

                if(cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    var discount = await _discountService.GetDiscount(requestStream.Current.DiscountCode);
                    _logger.LogInformation("REGULAR: {newAddedCartItem.Price}", newAddedCartItem.Price);
                  
                    newAddedCartItem.Price -= discount.Amount;
                    _logger.LogInformation("DISCOUNT : {newAddedCartItem.Price}", newAddedCartItem.Price);
                    shoppingCart.Items.Add(newAddedCartItem);
                    



                }
            }
            var insertCount = await _shoppingCartContext.SaveChangesAsync();

            var response = new AddItemIntoShoppingCartResponse
            {
                Success = insertCount > 0,
                InsertCount = insertCount
            };
            return response;


        }
    }
}
