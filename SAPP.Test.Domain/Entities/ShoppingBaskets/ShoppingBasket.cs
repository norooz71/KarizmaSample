using Karizma.Sample.Domain.Entities.Base;
using Karizma.Sample.Domain.Entities.Orders;
using Karizma.Sample.Domain.Entities.Products;
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

        public int PriceAtBuyTime { get; set; }

        public int ProfitAtBuyTime { get; set; }

        #region Navigation Properties
        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        #endregion
    }
}
