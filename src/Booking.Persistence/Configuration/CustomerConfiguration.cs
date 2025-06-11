using Booking.Domain.Entities.Customer;
using Booking.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Persistence.Configuration
{
    internal class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder)
        {
            entityBuilder.HasKey(c => c.CustomerId);
            entityBuilder.Property(c => c.FullName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(c => c.DocumentNumber).IsRequired();

            entityBuilder.HasMany(c => c.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}
