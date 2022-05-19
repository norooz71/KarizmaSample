using AutoMapper;
using Karizma.Sample.Domain.Entities.Orders;
using Karizma.Sample.Domain.Entities.ShoppingBaskets;
using Karizma.Sample.Domain.Enums;
using Karizma.Sample.Domain.Repositories;
using Karizma.Sample.Services.Abstractions.Dtos;
using Karizma.Sample.Services.Abstractions.Order;
using Karizma.Sample.Services.Factories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karizma.Sample.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        private IOptions<PriceCalculatingSetting> _config;

        private readonly PriceCalculatingSetting priceSetting;

        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IOptions<PriceCalculatingSetting> config,IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _config = config;

            priceSetting = config.Value;

            _mapper = mapper;
        }

        public async Task Add(int userId)
        {
            var shoppingBaskets = await _unitOfWork.GetRepository<ShoppingBasket>()
                .GetAllAccending(s => s.UserId == userId && s.Status==PayStatus.NotPay, s => s.Id, "Product");

            var order =await MakeOrder(userId, shoppingBaskets);

            order.ShoppingBaskets = shoppingBaskets;

            await _unitOfWork.GetRepository<Order>().Create(order);

            var result=await _unitOfWork.SaveChangesAsync();

        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var orders =await _unitOfWork.GetRepository<Order>().GetAllAccending(o=>true, o => o.Id, "ShoppingBaskets");

            var result = new List<OrderDto>();

            var order = orders.First();

            try
            {
                 var x = _mapper.Map<OrderDto>(order);

            }
            catch (Exception ex)
            {

            }

            try
            {
                var f = _mapper.Map<IEnumerable<OrderDto>>(orders);

            }
            catch (Exception ex)
            {

            }

            return result;
        } 


        private async Task<Order> MakeOrder(int userId,IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            return  new Order
            {
                UserId = userId,
                CreateTime = System.DateTime.Now,
                Status = Domain.Enums.PayStatus.NotPay,
                FinalPrice = await CalculatePice(userId),
                DisCountAmount = priceSetting.OrderDiscountAmountEnable ? priceSetting.OrderDiscountAmount : 0,
                DiscountPercent = priceSetting.OrderDiscountPercentEnable ? priceSetting.OrderDiscountPercent : 0,
                postType = await GetOrderPostType(userId),

            };
        }

        public async Task<decimal> CalculatePice(int userId)
        {
            var shoppingBaskets = await _unitOfWork.GetRepository<ShoppingBasket>().GetAllAccending(s => s.UserId == userId && s.Status==PayStatus.NotPay, s => s.Id, "Product");

            var calculatingType = new CalculatingType(_config);

            var condition = calculatingType.Set();

            return condition.Calculate(shoppingBaskets);

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

    }
}
