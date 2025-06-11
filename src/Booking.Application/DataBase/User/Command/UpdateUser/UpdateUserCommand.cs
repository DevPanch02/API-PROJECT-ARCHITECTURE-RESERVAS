using AutoMapper;
using Booking.Domain.Entities.Users;

namespace Booking.Application.DataBase.User.Command.UpdateUser
{
    public class UpdateUserCommand: IUpdateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateUserModel> ExecuteAsync(UpdateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            _dataBaseService.Users.Update(entity);

            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
