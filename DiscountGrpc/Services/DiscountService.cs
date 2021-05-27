using DiscountGrpc.Data;
using DiscountGrpc.Protos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountGrpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        public override Task<DiscountModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var discount = DiscountContext.discounts.FirstOrDefault(x => x.Code == request.DiscountCode);

            Console.WriteLine("Discount found");

            return Task.FromResult(new DiscountModel
            {
                DiscountId = discount.DiscountId,
                Code = discount.Code,
                Amount = discount.Amount
            });
        
        }
    }
}
