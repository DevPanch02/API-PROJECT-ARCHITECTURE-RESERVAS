namespace Booking.Application.DataBase.Customer.Queries.GetCustomerDocument
{
    public interface IGetCustomerDocumentQuery
    {
        Task<GetCustomerDocumentModel> ExecuteAsync(string documentNumber);
    }
}
