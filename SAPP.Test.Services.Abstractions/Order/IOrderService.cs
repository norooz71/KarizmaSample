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

        Task<int> CalculatePice(int userId);
    }
}
