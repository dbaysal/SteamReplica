using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NLayer.Repository.Seeds
{
    public class GenreSeed : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(new Genre
            {
                Id = 1,
                Name = "RPG"
            }, new Genre
            {
                Id = 2,
                Name = "MMORPG"
            }, new Genre
            {
                Id = 3,
                Name = "FPS"
            }, new Genre
            {
                Id = 4,
                Name = "Puzzle"
            }, new Genre
            {
                Id = 5,
                Name = "JRPG"
            });
        }
    }
}
