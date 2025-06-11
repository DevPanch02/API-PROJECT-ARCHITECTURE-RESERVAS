﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase.User.Queries.GetAllUser
{
    public class GetAllUserQuery: IGetAllUserQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllUserQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetUserModel>> ExecuteAsync()
        {
            var users = await _dataBaseService.Users.ToListAsync();
            return _mapper.Map<List<GetUserModel>>(users);
        }
    }
}
