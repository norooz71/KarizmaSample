using Karizma.Sample.Services.Abstractions.Order;

namespace Karizma.Sample.Services.Abstractions
{
    public interface IServiceManager
    {
        IOrderService OrderService { get; }
    }
}
