using Karizma.Sample.Domain.Entities.ShoppingBaskets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Persistance.Configurations
{
    internal sealed class ShoppingBasketConfiguration : IEntityTypeConfiguration<ShoppingBasket>
    {
        public void Configure(EntityTypeBuilder<ShoppingBasket> builder)
        {
            builder.ToTable(nameof(ShoppingBasket));

            builder.HasKey(x => x.Id);

        }
    }

}
