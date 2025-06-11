using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DataBase.User.Command.UpdateUserPassword
{
    public interface IUpdateUserPasswordCommand
    {
        Task<bool> ExecuteAsync(UpdateUserPasswordModel model);
    }
}
