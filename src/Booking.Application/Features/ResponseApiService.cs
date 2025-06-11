using Booking.Domain.Models;

namespace Booking.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(int statusCode, object data=null, string msg=null)
        {
            bool success = false;
            if (statusCode >= 200 && statusCode < 300)
            {
                success = true;
            }

            var result = new BaseResponseModel
            {
                StatusCode = statusCode,
                Success = success,
                Message = msg,
                Data = data
            };
            return result;
        }
    }
}
