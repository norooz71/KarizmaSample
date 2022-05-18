using Karizma.Sample.Domain.Entities.Base;
using Karizma.Sample.Domain.Entities.ShoppingBaskets;
using Karizma.Sample.Domain.Enums;
using System.Collections.Generic;

namespace Karizma.Sample.Domain.Entities.Products
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public ProductType Type { get; set; }

        public int ProfitAmount { get; set; }



        #region Navigation Properties

        public virtual ICollection<ShoppingBasket> ShoppingBaskets { get; set; }

        #endregion

    }
}
