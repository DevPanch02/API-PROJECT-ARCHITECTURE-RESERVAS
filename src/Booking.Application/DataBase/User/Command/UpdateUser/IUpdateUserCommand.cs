namespace Booking.Application.DataBase.User.Command.UpdateUser
{
    public interface IUpdateUserCommand
    {
        Task<UpdateUserModel> ExecuteAsync(UpdateUserModel model);
    }
}
