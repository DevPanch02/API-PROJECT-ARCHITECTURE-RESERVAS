using AutoMapper;
using Booking.Domain.Entities.Customer;

namespace Booking.Application.DataBase.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand: ICreateCustomerCommand
    {
        private readonly IDataBaseService _dataBase;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IDataBaseService dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        public async Task<CreateCustomerModel> ExecuteAsync(CreateCustomerModel model)
        {
            var customerEntity = _mapper.Map<CustomerEntity>(model);
            await _dataBase.Customer.AddAsync(customerEntity);
            await _dataBase.SaveAsync();

            return model;
        }
    }
}
