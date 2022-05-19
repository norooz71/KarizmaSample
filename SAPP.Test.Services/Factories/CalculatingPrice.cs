using Karizma.Sample.Domain.Entities.ShoppingBaskets;
using Karizma.Sample.Services.Abstractions.Dtos;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Karizma.Sample.Services.Factories
{
    public class CalculatingType
    {
        public readonly IOptions<PriceCalculatingSetting> _priceCalculatingSetting;
        
        public readonly PriceCalculatingSetting _setting;


        public CalculatingType(IOptions<PriceCalculatingSetting> priceCalculatingSetting)
        {
            _priceCalculatingSetting = priceCalculatingSetting;

            _setting = _priceCalculatingSetting.Value;
        }
        public   CalculatingPrice Set()
        {

            if (!_setting.OrderDiscountPercentEnable && !_setting.OrderDiscountAmountEnable && !_setting.ProductProfitEnable )
            {
                return new NoDiscountPercentNoDiscountAmountNoProfit(_priceCalculatingSetting);
            }
            
            if (_setting.OrderDiscountPercentEnable && _setting.OrderDiscountAmountEnable && _setting.ProductProfitEnable )
            {
                return new DiscountPercentDiscountAmountProfit(_priceCalculatingSetting);
            } 
            
            if (_setting.OrderDiscountPercentEnable && _setting.OrderDiscountAmountEnable && !_setting.ProductProfitEnable )
            {
                return new DiscountPercentDiscountAmountNoProfit(_priceCalculatingSetting);
            }   
            
            if (!_setting.OrderDiscountPercentEnable && _setting.OrderDiscountAmountEnable && !_setting.ProductProfitEnable )
            {
                return new NoDiscountPercentDiscountAmountNoProfit(_priceCalculatingSetting);
            }
            
            if (!_setting.OrderDiscountPercentEnable && !_setting.OrderDiscountAmountEnable && _setting.ProductProfitEnable )
            {
                return new NoDiscountPercentNoDiscountAmountProfit(_priceCalculatingSetting);
            }
            
            if (!_setting.OrderDiscountPercentEnable && _setting.OrderDiscountAmountEnable && _setting.ProductProfitEnable )
            {
                return new NoDiscountPercentDiscountAmountProfit(_priceCalculatingSetting);
            }

            return  new DiscountPercentDiscountAmountProfit(_priceCalculatingSetting);
        }
    }

    public abstract class CalculatingPrice
    {
        public readonly PriceCalculatingSetting _priceCalculatingSetting;
        public CalculatingPrice(IOptions<PriceCalculatingSetting> PriceCalculatingSetting)
        {
            _priceCalculatingSetting=PriceCalculatingSetting.Value; 
        }
        public abstract decimal Calculate(IEnumerable<ShoppingBasket> shoppingBaskets);
    }

    public class NoDiscountPercentNoDiscountAmountNoProfit : CalculatingPrice
    {
        public NoDiscountPercentNoDiscountAmountNoProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override decimal Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            return shoppingBaskets.Sum(s => s.Product.Price);
        }
    }

    public class NoDiscountPercentNoDiscountAmountProfit : CalculatingPrice
    {
        public NoDiscountPercentNoDiscountAmountProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override decimal Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
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

        public override decimal Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
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

        public override decimal Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
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

        public override decimal Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            var shoppingBasketsPrice = shoppingBaskets.Sum(s => s.Product.Price);

            var profit = shoppingBaskets.Count() * _priceCalculatingSetting.productProfitAmount;

            var Discount = (shoppingBasketsPrice + profit) * _priceCalculatingSetting.OrderDiscountPercent;

            return shoppingBasketsPrice + profit - Discount - _priceCalculatingSetting.OrderDiscountAmount;
        }
    }
    public class NoDiscountPercentDiscountAmountNoProfit : CalculatingPrice
    {
        public NoDiscountPercentDiscountAmountNoProfit(IOptions<PriceCalculatingSetting> PriceCalculatingSetting) : base(PriceCalculatingSetting)
        {
        }

        public override decimal Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
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

        public override decimal Calculate(IEnumerable<ShoppingBasket> shoppingBaskets)
        {
            var shoppingBasketsPrice = shoppingBaskets.Sum(s => s.Product.Price);

            var Discount = shoppingBasketsPrice  * _priceCalculatingSetting.OrderDiscountAmount;

            return shoppingBasketsPrice - Discount - _priceCalculatingSetting.OrderDiscountAmount;
        }
    }
   
}
