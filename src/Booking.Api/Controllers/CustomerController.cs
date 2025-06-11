using Booking.Application.DataBase.Customer.Command.CreateCustomer;
using Booking.Application.DataBase.Customer.Command.DeleteCustomer;
using Booking.Application.DataBase.Customer.Command.UpdateCustomer;
using Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Booking.Application.DataBase.Customer.Queries.GetCustomerDocument;
using Booking.Application.Exceptions;
using Booking.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerModel model,
            [FromServices] ICreateCustomerCommand createCustomer)
        {
            var customer = await createCustomer.ExecuteAsync(model);
            if (customer == null)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, "User creation failed."));

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, customer, "User created successfully."));

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateCustomerModel model,
            [FromServices] IUpdateCustomerCommand updateCustomer)
        {
            var customer = await updateCustomer.ExecuteAsync(model);
            if (customer == null)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, "User update failed."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, customer, "User updated successfully."));
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(int customerId,
            [FromServices] IDeleteCustomerCommand deleteCustomer)
        {
            var result = await deleteCustomer.ExecuteAsync(customerId);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, "User deletion failed."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, null, "User deleted successfully."));
        }

        [HttpGet("get-customer")]
        public async Task<IActionResult> GetAllCustomers(
            [FromServices] IGetAllCustomerQuery getAllCustomers)
        {
            var customers = await getAllCustomers.ExecuteAsync();
            if (customers == null || !customers.Any())
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No customers found."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, customers, "Customers retrieved successfully."));
        }

        [HttpGet("get-customer/{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId,
            [FromServices] IGetCustomerByIdQuery getCustomerById)
        {
            if (customerId <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Invalid customer ID."));

            var customer = await getCustomerById.ExecuteAsync(customerId);
            if (customer == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "Customer not found."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, customer, "Customer retrieved successfully."));
        }

        [HttpGet("customer-document/{document}")]
        public async Task<IActionResult> GetCustomerDocument(string document,
            [FromServices] IGetCustomerDocumentQuery getCustomerDocument)
        {
            var customer = await getCustomerDocument.ExecuteAsync(document);
            if (customer == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "Customer document not found."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, document, "Customer document retrieved successfully."));
        }
    }
}
