﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery: IGetCustomerByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdModel> ExecuteAsync(int customerId)
        {
            var customerEntity = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customerEntity == null)
            {
                return null;
            }
            return _mapper.Map<GetCustomerByIdModel>(customerEntity);
        }
    }
}
