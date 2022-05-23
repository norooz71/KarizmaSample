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
                CreateMap<Order,OrderDto>().ReverseMap();
                CreateMap<ShoppingBasket,ShoppingBasketDto>().ReverseMap();
                CreateMap<Product,ProductDto>().ReverseMap();

        }

    }
}
