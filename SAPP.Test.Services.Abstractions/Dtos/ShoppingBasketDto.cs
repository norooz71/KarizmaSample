using Karizma.Sample.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Services.Abstractions.Dtos
{
    public class ShoppingBasketDto
    {
        public int UserId { get; set; }

        public decimal PriceAtBuyTime { get; set; }

        public decimal ProfitAtBuyTime { get; set; }

        public PayStatus Status { get; set; }

        #region Navigation Properties

        public int ProductId { get; set; }
        public  ProductDto Product { get; set; }

        public int? OrderId { get; set; }
        public virtual OrderDto Order { get; set; }

        #endregion

    }
}
