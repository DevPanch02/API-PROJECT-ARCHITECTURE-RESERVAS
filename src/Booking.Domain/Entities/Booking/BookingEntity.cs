using Booking.Domain.Entities.Customer;
using Booking.Domain.Entities.Users;

namespace Booking.Domain.Entities.Booking
{
    public class BookingEntity
    {
        public int BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }

        public CustomerEntity Customer { get; set; }
        public UserEntity User { get; set; }
    }
}
