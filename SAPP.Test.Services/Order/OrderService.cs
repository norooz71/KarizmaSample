using Karizma.Sample.Domain.Entities.Orders;
using Karizma.Sample.Domain.Entities.ShoppingBaskets;
using Karizma.Sample.Domain.Enums;
using Karizma.Sample.Domain.Repositories;
using Karizma.Sample.Services.Abstractions.Dtos;
using Karizma.Sample.Services.Abstractions.Order;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karizma.Sample.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly PriceCalculatingSetting priceSetting;

        public OrderService(IUnitOfWork unitOfWork, IOptions<PriceCalculatingSetting> config)
        {
            _unitOfWork = unitOfWork;

            priceSetting = config.Value;
        }

        public async Task Add(int userId)
        {
            var shoppingBaskets = await _unitOfWork.GetRepository<ShoppingBasket>().GetAllAccending(s => s.UserId == userId, s => s.Id, "Product");

            var order =await MakeOrder(userId, shoppingBaskets);  

            await _unitOfWork.GetRepository<Order>().Create(order);

            var result=await _unitOfWork.SaveChangesAsync();

            await UpdateShoppingBaskets(userId,result);
        }

        private async Task<Order> MakeOrder(int userId,IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            return  new Order
            {
                UserId = userId,
                CreateTime = System.DateTime.Now,
                Status = Domain.Enums.OrderStatus.NotPay,
                FinalPrice = await CalculatePice(userId),
                DisCountAmount = priceSetting.OrderDiscountAmountEnable ? priceSetting.OrderDiscountAmount : 0,
                DiscountPercent = priceSetting.OrderDiscountPercentEnable ? priceSetting.OrderDiscountPercent : 0,
                postType = await GetOrderPostType(userId),

            };
        }

        public async Task<int> CalculatePice(int userId)
        {
            var shoppingBaskets = await _unitOfWork.GetRepository<ShoppingBasket>().GetAllAccending(s => s.UserId == userId, s => s.Id, "Product");

            var price = shoppingBaskets.Sum(s => s.Product.Price);

            var productProfit = priceSetting.ProductProfitEnable ? shoppingBaskets.Count() * priceSetting.productProfitAmount : 0;

            var orderDiscountPercent = priceSetting.OrderDiscountPercentEnable ? priceSetting.OrderDiscountPercent : 0;

            var orderDiscountAmount = priceSetting.OrderDiscountAmountEnable ? priceSetting.OrderDiscountAmount : 0;

            return 10;

        }

        private async Task<PostType> GetOrderPostType(int userId)
        {
            var shoppingBaskets = await _unitOfWork.GetRepository<ShoppingBasket>().GetAllAccending(s => s.UserId == userId, s => s.Id, "Product");

            if (shoppingBaskets.Any(s=>s.Product.Type==ProductType.Breakable))
            {
                return PostType.Express;
            }

            return PostType.Usual;
        }

        private async Task UpdateShoppingBaskets(int userId,int orderId)
        {
            var shoppingBaskets = await _unitOfWork.GetRepository<ShoppingBasket>().GetAllAccending(s => s.UserId == userId, s => s.Id, "Product");

            foreach (var item in shoppingBaskets)
            {
                item.OrderId = orderId;

                item.UpdateTime = System.DateTime.Now;
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
