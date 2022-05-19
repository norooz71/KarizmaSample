namespace Karizma.Sample.Services.Abstractions.Dtos
{
    public class PriceCalculatingSetting
    {
        public bool ProductProfitEnable { get; set; }

        public decimal productProfitAmount { get; set; }

        public bool OrderDiscountPercentEnable { get; set; }

        public decimal OrderDiscountPercent { get; set; }

        public bool OrderDiscountAmountEnable { get; set; }

        public int OrderDiscountAmount { get; set; }
    }
}
