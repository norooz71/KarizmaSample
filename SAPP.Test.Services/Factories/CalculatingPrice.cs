using Karizma.Sample.Domain.Entities.ShoppingBaskets;
using Karizma.Sample.Services.Abstractions.Dtos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Services.Factories
{
    public class CalculatingType
    {
        public readonly IOptions<PriceCalculatingSetting> _setting;
        public CalculatingType(IOptions<PriceCalculatingSetting> Setting)
        {
            _setting = Setting.Value;
        }
        public   CalculatingPrice Set()
        {
            condition condition = condition.a;

            if (!_setting.OrderDiscountPercentEnable && !_setting.OrderDiscountAmountEnable && !_setting.ProductProfitEnable )
            {
                return new NoDiscountPercentNoDiscountAmountNoProfit(_setting);
            }

        }
    }

        public enum condition
        {
            a,
            b,
            c
        }


    public abstract class CalculatingPrice
    {
        public readonly PriceCalculatingSetting _priceCalculatingSetting;
        public CalculatingPrice(IOptions<PriceCalculatingSetting> PriceCalculatingSetting)
        {
            _priceCalculatingSetting=PriceCalculatingSetting.Value; 
        }
        public abstract int Calculate(IEnumerable<ShoppingBasket> shoppingBaskets);
    }

    public class NoDiscountPercentNoDiscountAmountNoProfit : CalculatingPrice
    {
        public NoDiscountPercentNoDiscountAmountNoProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override int Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            return shoppingBaskets.Sum(s => s.Product.Price);
        }
    }

    public class NoDiscountPercentNoDiscountAmountProfit : CalculatingPrice
    {
        public NoDiscountPercentNoDiscountAmountProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override int Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            var shoppingBasketsPrice=shoppingBaskets.Sum(s=>s.Product.Price);

            var profit = shoppingBaskets.Count() * _priceCalculatingSetting.productProfitAmount;

            return shoppingBasketsPrice + profit;
        }
    }
    public class NoDiscountPercentDiscountAmountProfit : CalculatingPrice
    {
        public NoDiscountPercentDiscountAmountProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override int Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            var shoppingBasketsPrice = shoppingBaskets.Sum(s => s.Product.Price);

            var profit = shoppingBaskets.Count() * _priceCalculatingSetting.productProfitAmount;

            return shoppingBasketsPrice + profit - _priceCalculatingSetting.productProfitAmount;
        }
    }
    public class DiscountPercentNoDiscountAmountProfit : CalculatingPrice
    {
        public DiscountPercentNoDiscountAmountProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override int Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            var shoppingBasketsPrice = shoppingBaskets.Sum(s => s.Product.Price);

            var profit = shoppingBaskets.Count() * _priceCalculatingSetting.productProfitAmount;

            var Discount = (shoppingBasketsPrice + profit) * _priceCalculatingSetting.OrderDiscountAmount;

            return shoppingBasketsPrice +  profit - Discount;
        }
    }
    public class DiscountPercentDiscountAmountProfit : CalculatingPrice
    {
        public DiscountPercentDiscountAmountProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override int Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            var shoppingBasketsPrice = shoppingBaskets.Sum(s => s.Product.Price);

            var profit = shoppingBaskets.Count() * _priceCalculatingSetting.productProfitAmount;

            var Discount = (shoppingBasketsPrice + profit) * _priceCalculatingSetting.OrderDiscountAmount;

            return shoppingBasketsPrice + profit - Discount - _priceCalculatingSetting.OrderDiscountAmount;
        }
    }
    public class NoDiscountPercentDiscountAmountNoProfit : CalculatingPrice
    {
        public NoDiscountPercentDiscountAmountNoProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override int Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            var shoppingBasketsPrice = shoppingBaskets.Sum(s => s.Product.Price);

            var profit = shoppingBaskets.Count() * _priceCalculatingSetting.productProfitAmount;

            return shoppingBasketsPrice+profit - _priceCalculatingSetting.OrderDiscountAmount;
        }
    }
    public class DiscountPercentDiscountAmountNoProfit : CalculatingPrice
    {
        public DiscountPercentDiscountAmountNoProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override int Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            var shoppingBasketsPrice = shoppingBaskets.Sum(s => s.Product.Price);

            var Discount = shoppingBasketsPrice  * _priceCalculatingSetting.OrderDiscountAmount;

            return shoppingBasketsPrice - Discount - _priceCalculatingSetting.OrderDiscountAmount;
        }
    }
   
}
