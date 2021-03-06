using Karizma.Sample.Domain.Entities.Base;
using Karizma.Sample.Domain.Entities.ShoppingBaskets;
using Karizma.Sample.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        public PayStatus Status { get; set; }

        public decimal FinalPrice { get; set; }

        public PostType postType { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal DisCountAmount { get; set; }

        public ICollection<ShoppingBasket> ShoppingBaskets { get; set; }
    }
}
