using Karizma.Sample.Domain.Repositories;
using Karizma.Sample.Services.Abstractions;
using Karizma.Sample.Services.Abstractions.Dtos;
using Karizma.Sample.Services.Abstractions.Order;
using Karizma.Sample.Services.OrderServices;
using Microsoft.Extensions.Options;
using System;

namespace Karizma.Sample.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        
        private readonly Lazy<IOrderService> _lazyOrderService;

        public ServiceManager(IUnitOfWork unitOfWork,IOptions<PriceCalculatingSetting> config)
        {
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(unitOfWork,config));

        }

        public IOrderService OrderService => _lazyOrderService.Value;
    }
}
