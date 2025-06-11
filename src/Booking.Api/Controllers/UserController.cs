using Booking.Application.DataBase.User.Command.CreateUser;
using Booking.Application.DataBase.User.Command.DeleteUser;
using Booking.Application.DataBase.User.Command.UpdateUser;
using Booking.Application.DataBase.User.Command.UpdateUserPassword;
using Booking.Application.DataBase.User.Queries.GetAllUser;
using Booking.Application.DataBase.User.Queries.GetUserById;
using Booking.Application.DataBase.User.Queries.GetUserData;
using Booking.Application.Exceptions;
using Booking.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(
                [FromBody] CreateUserModel model,
                [FromServices] ICreateUserCommand createUser)
        {
            var data = await createUser.ExecuteAsync(model);
            if (data == null)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, "User creation failed."));

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, "User created successfully."));

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
                [FromBody] UpdateUserModel model,
                [FromServices] IUpdateUserCommand updateUser)
        {
            var data = await updateUser.ExecuteAsync(model);
            if (data == null)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, "User update failed."));
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "User updated successfully."));

        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(
                [FromBody] UpdateUserPasswordModel model,
                [FromServices] IUpdateUserPasswordCommand updateUser)
        {
            var data = await updateUser.ExecuteAsync(model);
            if (!data)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, "User password update failed."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "User password updated successfully."));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> UpdatePassword(int userId,
            [FromServices] IDeleteUserCommand deleteUser)
        {
            if (userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "User ID is required."));

            var data = await deleteUser.ExecuteAsync(userId);
            if (!data)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, "User deletion failed."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "User deleted successfully."));
        }

        [HttpGet("user-all")]
        public async Task<IActionResult> GetAllUsers([FromServices] IGetAllUserQuery userAll)
        {
            var users = await userAll.ExecuteAsync();
            if (users == null || !users.Any())
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No users found."));
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, users, "Users retrieved successfully."));
        }

        [HttpGet("user-by-id/{userId}")]
        public async Task<IActionResult> GetByIdUsers(int userId, [FromServices] IGetUserByIdQuery userAll)
        {
            if (userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "User ID is required."));

            var user = await userAll.ExecuteAsync(userId);
            if (user == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "User not found."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, user, "User retrieved successfully."));
        }

        [HttpGet("username-by-password/{userName}/{password}")]
        public async Task<IActionResult> GetUserNameByPassword(string userName, string password, 
            [FromServices] IGetUserPasswordQuery userNamePassword)
        {
            var user = await userNamePassword.ExecuteAsync(userName,password);
            if (user == null)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent, null, "User not found."));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, user, "User retrieved successfully."));
        }
    }
}
