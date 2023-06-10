using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    public class BasketSeed : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasData(new Basket
            {
                Id = 1,
                UserId = 1,

            }, new Basket
            {
                Id = 2,
                UserId = 2,

            }, new Basket
            {
                Id = 3,
                UserId = 3,

            }, new Basket
            {
                Id = 4,
                UserId = 4,

            });
        }
    }
}
