using AutoMapper;
using Booking.Domain.Entities.Booking;

namespace Booking.Application.DataBase.Bookings.Command.CreateBooking
{
    public class CreateBookingCommand: ICreateBookingCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateBookingCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateBookingModel> ExecuteAsync(CreateBookingModel model)
        {
            var bookingEntity = _mapper.Map<BookingEntity>(model);
            bookingEntity.RegisterDate = DateTime.UtcNow;
            await _dataBaseService.Booking.AddAsync(bookingEntity);
            await _dataBaseService.SaveAsync();

            return model;
        }
    }
}
