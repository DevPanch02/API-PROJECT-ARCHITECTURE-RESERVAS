using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase.User.Command.UpdateUserPassword
{
    public class UpdateUserPasswordCommand: IUpdateUserPasswordCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public UpdateUserPasswordCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> ExecuteAsync(UpdateUserPasswordModel model)
        {
            var user = await _dataBaseService.Users.FirstOrDefaultAsync(x => x.UserId == model.UserId);
            if (user == null)
            {
                return false; // User not found
            }
            user.Password = model.Password;
            return await _dataBaseService.SaveAsync();
        }
    }
}
