using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Booking.Application.DataBase.Customer.Queries.GetCustomerDocument
{
    public class GetCustomerDocumentQuery: IGetCustomerDocumentQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerDocumentQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerDocumentModel> ExecuteAsync(string documentNumber)
        {
            var customerDocument = await _dataBaseService.Customer.FirstOrDefaultAsync(x=>x.DocumentNumber==documentNumber);
            if (customerDocument == null)
            {
                return null; // or throw an exception, depending on your error handling strategy
            }
            return _mapper.Map<GetCustomerDocumentModel>(customerDocument);
        }
    }
}
