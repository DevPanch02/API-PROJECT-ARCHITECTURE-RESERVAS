namespace Booking.Application.DataBase.Bookings.Queries.GetBookingType
{
    public class GetBookingTypeModel
    {
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerDocumentNumber { get; set; }
    }
}
