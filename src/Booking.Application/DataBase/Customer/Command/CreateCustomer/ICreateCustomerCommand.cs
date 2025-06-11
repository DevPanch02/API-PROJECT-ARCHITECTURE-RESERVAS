namespace Booking.Application.DataBase.Customer.Command.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        Task<CreateCustomerModel> ExecuteAsync(CreateCustomerModel model);
    }
}
