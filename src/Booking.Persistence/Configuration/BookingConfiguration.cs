using Booking.Domain.Entities.Booking;
using Booking.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Persistence.Configuration
{
    internal class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityBuilder)
        {
            entityBuilder.HasKey(b => b.BookingId);
            entityBuilder.Property(b => b.RegisterDate).IsRequired();
            entityBuilder.Property(b => b.Code).IsRequired();
            entityBuilder.Property(b => b.Type).IsRequired();
            entityBuilder.Property(b => b.UserId).IsRequired();
            entityBuilder.Property(b => b.CustomerId).IsRequired();

            entityBuilder.HasOne(b => b.User)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.UserId);

            entityBuilder.HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}
