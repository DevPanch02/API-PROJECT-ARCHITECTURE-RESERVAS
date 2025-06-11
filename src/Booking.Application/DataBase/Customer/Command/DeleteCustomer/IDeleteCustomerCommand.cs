namespace Booking.Application.DataBase.Customer.Command.DeleteCustomer
{
    public interface IDeleteCustomerCommand
    {
        Task<bool> ExecuteAsync(int customerId);
    }
}
