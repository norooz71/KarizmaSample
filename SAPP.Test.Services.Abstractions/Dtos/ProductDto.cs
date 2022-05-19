using Karizma.Sample.Domain.Enums;

namespace Karizma.Sample.Services.Abstractions.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductType Type { get; set; }

    }
}
