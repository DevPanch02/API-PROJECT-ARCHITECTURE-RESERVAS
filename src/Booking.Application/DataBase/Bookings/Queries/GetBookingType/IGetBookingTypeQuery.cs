using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DataBase.Bookings.Queries.GetBookingType
{
    public interface IGetBookingTypeQuery
    {
        Task<List<GetBookingTypeModel>> ExecuteAsync(string type);
    }
}
