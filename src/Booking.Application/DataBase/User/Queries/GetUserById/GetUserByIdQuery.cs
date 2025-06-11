using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase.User.Queries.GetUserById
{
    public class GetUserByIdQuery: IGetUserByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByIdModel> ExecuteAsync(int userId)
        {
            var user = await _dataBaseService.Users.FirstOrDefaultAsync(x=>x.UserId == userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }
            return _mapper.Map<GetUserByIdModel>(user);
        }
    }
}
