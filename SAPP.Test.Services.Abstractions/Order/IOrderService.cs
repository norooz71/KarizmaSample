using Karizma.Sample.Services.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Services.Abstractions.Order
{
    public interface IOrderService
    {
        Task Add(int userId);

        Task<IEnumerable<OrderDto>> GetAll();

        Task<decimal> CalculatePice(int userId);
    }
}
