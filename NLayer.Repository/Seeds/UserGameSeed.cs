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
    public class UserGameSeed : IEntityTypeConfiguration<UserGame>
    {
        public void Configure(EntityTypeBuilder<UserGame> builder)
        {
            builder.HasData(new UserGame
            {
                GameId = 1,
                UserId = 1,
                PlayTime = 75
            }, new UserGame
            {
                GameId = 7,
                UserId = 1,
                PlayTime = 60
            }, new UserGame
            {
                GameId = 8,
                UserId = 1,
                PlayTime = 55
            }, new UserGame
            {
                GameId = 9,
                UserId = 1,
                PlayTime = 42
            }, new UserGame
            {
                GameId = 10,
                UserId = 1,
                PlayTime = 39
            });
        }
    }
}
