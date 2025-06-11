using AutoMapper;
using Booking.Domain.Entities.Customer;
using Booking.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DataBase.Customer.Command.UpdateCustomer
{
    public class UpdateCustomerCommand: IUpdateCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateCustomerCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerModel> ExecuteAsync(UpdateCustomerModel model)
        {

            var entity = _mapper.Map<CustomerEntity>(model);
            if (entity == null)
            {
                throw new Exception("Customer not found");
            }
            _dataBaseService.Customer.Update(entity);
            await _dataBaseService.SaveAsync();

            return model;
        }
    }
}
