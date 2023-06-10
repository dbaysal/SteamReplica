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
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id = 1,
                Username = "Dogukan",
                Password = "123",
                Role = "normal_user"
            }, new User
            {
                Id = 2,
                Username = "Tuana",
                Password = "1234",
                Role = "normal_user"
            }, new User
            {
                Id = 3,
                Username = "Handan",
                Password = "1234",
                Role = "normal_user"
            }, new User
            {
                Id = 4,
                Username = "Hakan",
                Password = "1234",
                Role = "normal_user"
            });
        }
    }
}
