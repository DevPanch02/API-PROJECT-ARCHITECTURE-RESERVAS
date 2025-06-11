using Booking.Application.DataBase.Bookings.Command.CreateBooking;
using Booking.Application.DataBase.Bookings.Command.UpdateBooking;
using Booking.Application.DataBase.Bookings.Queries.GetAllBooking;
using Booking.Application.DataBase.Bookings.Queries.GetBookingDocumentNumber;
using Booking.Application.DataBase.Bookings.Queries.GetBookingType;
using Booking.Application.Exceptions;
using Booking.Application.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateBooking(
            [FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand createBooking)
        {
            var booking = await createBooking.ExecuteAsync(model);
            if (booking == null)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, "Booking creation failed."));

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, booking, "Booking created successfully."));
        }
        /*
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBooking(
            [FromBody] UpdateBookingModel model,
            [FromServices] IUpdateBookingCommand updateBooking)
        {
            var booking = await updateBooking.ExecuteAsync(model);
            if (booking == null)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, "Booking update failed."));
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, booking, "Booking updated successfully."));
        }*/

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBooking([FromServices] IGetAllBookingQuery getAllBooking)
        {
            var bookings = await getAllBooking.ExecuteAsync();
            if (bookings == null || !bookings.Any())
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No bookings found."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, bookings, "Bookings retrieved successfully."));
        }

        [HttpGet("get-by-document")]
        public async Task<IActionResult> GetBookingByDocument(string documentNumber,
            [FromServices] IGetBookingDocumentNumberQuery getBookingByDocument)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Document number is required."));

            var booking = await getBookingByDocument.ExecuteAsync(documentNumber);
            if (booking == null || booking.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No booking found for the provided document number."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, booking, "Booking retrieved successfully."));
        }

        [HttpGet("get-by-type")]
        public async Task<IActionResult> GetBookingByType([FromQuery] string type,
            [FromServices] IGetBookingTypeQuery getBookingByType)
        {
            if (string.IsNullOrEmpty(type))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Booking type is required."));

            var booking = await getBookingByType.ExecuteAsync(type);
            if (booking == null || booking.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No booking found for the provided type."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, booking, "Booking retrieved successfully."));
        }
    }
}
