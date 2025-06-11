using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase.User.Queries.GetUserData
{
    public class GetUserPasswordQuery: IGetUserPasswordQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetUserPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserPasswordModel> ExecuteAsync(string userName, string pass)
        {
            var userEntity = await _dataBaseService.Users.FirstOrDefaultAsync(x=>x.UserName==userName && x.Password==pass);
            if (userEntity == null)
            {
                return null; // or throw an exception, depending on your error handling strategy
            }
            return _mapper.Map<GetUserPasswordModel>(userEntity);
        }
    }
}
