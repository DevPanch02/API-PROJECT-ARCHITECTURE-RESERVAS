using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DataBase.Bookings.Queries.GetBookingDocumentNumber
{
    public class GetBookingDocumentNumberQuery: IGetBookingDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        public GetBookingDocumentNumberQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingDocumentNumberModel>> ExecuteAsync(string documentNumber)
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                where customer.DocumentNumber == documentNumber
                                select new GetBookingDocumentNumberModel
                                {
                                    RegisterDate = booking.RegisterDate,
                                    Code = booking.Code,
                                    Type = booking.Type
                                }).ToListAsync();
            if (result == null || result.Count==0)
            {
                throw new Exception("Booking not found");
            }
            return result;
        }
    }
}
