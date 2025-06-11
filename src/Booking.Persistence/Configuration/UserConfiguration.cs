using Booking.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.HasKey(u => u.UserId);
            entityBuilder.Property(u => u.FirstName).IsRequired();
            entityBuilder.Property(u => u.LastName).IsRequired();
            entityBuilder.Property(u => u.UserName).IsRequired();
            entityBuilder.Property(u => u.Password).IsRequired();

            entityBuilder.HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                //.WithOne(b => b.Users)
                .HasForeignKey(b => b.UserId);
        }
    }
}
