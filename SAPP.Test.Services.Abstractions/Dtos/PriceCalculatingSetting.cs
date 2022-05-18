namespace Karizma.Sample.Services.Abstractions.Dtos
{
    public class PriceCalculatingSetting
    {
        public bool ProductProfitEnable { get; set; }

        public int productProfitAmount { get; set; }

        public bool OrderDiscountPercentEnable { get; set; }

        public int OrderDiscountPercent { get; set; }

        public bool OrderDiscountAmountEnable { get; set; }

        public int OrderDiscountAmount { get; set; }
    }
}
