using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DataBase.User.Command.CreateUser
{
    public interface ICreateUserCommand
    {
        Task<CreateUserModel> ExecuteAsync(CreateUserModel model);
    }
}
