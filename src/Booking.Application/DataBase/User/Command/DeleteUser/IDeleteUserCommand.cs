using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DataBase.User.Command.DeleteUser
{
    public interface IDeleteUserCommand
    {
        Task<bool> ExecuteAsync(int userId);
    }
}
