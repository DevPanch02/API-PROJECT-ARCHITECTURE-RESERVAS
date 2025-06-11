using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DataBase.Customer.Command.DeleteCustomer
{
    public class DeleteCustomerCommand: IDeleteCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public DeleteCustomerCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> ExecuteAsync(int customerId)
        {
            var customer = await _dataBaseService.Customer.FirstOrDefaultAsync(x=>x.CustomerId==customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            _dataBaseService.Customer.Remove(customer);
            await _dataBaseService.SaveAsync();

            return true;
        }
    }
}
