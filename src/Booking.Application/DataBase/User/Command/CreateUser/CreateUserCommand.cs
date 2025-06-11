using AutoMapper;
using Booking.Domain.Entities.Users;

namespace Booking.Application.DataBase.User.Command.CreateUser
{
    public class CreateUserCommand: ICreateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateUserModel> ExecuteAsync(CreateUserModel model)
        {
            var userEntity = _mapper.Map<UserEntity>(model);
            await _dataBaseService.Users.AddAsync(userEntity);

            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
