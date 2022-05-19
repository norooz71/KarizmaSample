using AutoMapper;
using Karizma.Sample.Domain.Entities.Orders;
using Karizma.Sample.Domain.Entities.Products;
using Karizma.Sample.Domain.Entities.ShoppingBaskets;
using Karizma.Sample.Services.Abstractions.Dtos;

namespace Karizma.Sample.Services
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderDto, Order>().ReverseMap();
                cfg.CreateMap<ShoppingBasketDto, ShoppingBasket>().ReverseMap();
                cfg.CreateMap<ProductDto, Product>().ReverseMap();
                
            });

        }

    }
}
