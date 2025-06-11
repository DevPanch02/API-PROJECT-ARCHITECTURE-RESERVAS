using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase.User.Command.DeleteUser
{
    public class DeleteUserCommand: IDeleteUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public DeleteUserCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> ExecuteAsync(int userId)
        {
            var user = await _dataBaseService.Users.FirstOrDefaultAsync(x=>x.UserId == userId);
            if (user == null)
            {
                return false; // User not found
            }
            _dataBaseService.Users.Remove(user);
            return await _dataBaseService.SaveAsync();
        }
    }
}
