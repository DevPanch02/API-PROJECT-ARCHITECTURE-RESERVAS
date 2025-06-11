using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DataBase.User.Queries.GetUserData
{
    public interface IGetUserPasswordQuery
    {
        Task<GetUserPasswordModel> ExecuteAsync(string userName, string pass);
    }
}
