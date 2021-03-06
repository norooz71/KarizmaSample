using Karizma.Sample.Domain.Entities.Base;
using Karizma.Sample.Domain.Entities.Orders;
using Karizma.Sample.Domain.Entities.Products;
using Karizma.Sample.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Domain.Entities.ShoppingBaskets
{
    public class ShoppingBasket:BaseEntity
    {
        public int UserId { get; set; }

        public decimal PriceAtBuyTime { get; set; }

        public decimal ProfitAtBuyTime { get; set; }

        public PayStatus Status { get; set; }

        #region Navigation Properties

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        #endregion
    }
}
