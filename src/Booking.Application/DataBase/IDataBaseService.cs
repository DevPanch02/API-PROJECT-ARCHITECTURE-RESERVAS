using Booking.Domain.Entities.Booking;
using Booking.Domain.Entities.Customer;
using Booking.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<CustomerEntity> Customer { get; set; }
        DbSet<BookingEntity> Booking { get; set; }
        Task<bool> SaveAsync();
    }
}
