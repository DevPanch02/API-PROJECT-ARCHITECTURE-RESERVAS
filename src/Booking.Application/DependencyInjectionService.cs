using AutoMapper;
using Booking.Application.Configuration;
using Booking.Application.DataBase.Bookings.Command.CreateBooking;
using Booking.Application.DataBase.Bookings.Queries.GetAllBooking;
using Booking.Application.DataBase.Bookings.Queries.GetBookingDocumentNumber;
using Booking.Application.DataBase.Bookings.Queries.GetBookingType;
using Booking.Application.DataBase.Customer.Command.CreateCustomer;
using Booking.Application.DataBase.Customer.Command.DeleteCustomer;
using Booking.Application.DataBase.Customer.Command.UpdateCustomer;
using Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Booking.Application.DataBase.Customer.Queries.GetCustomerDocument;
using Booking.Application.DataBase.User.Command.CreateUser;
using Booking.Application.DataBase.User.Command.DeleteUser;
using Booking.Application.DataBase.User.Command.UpdateUser;
using Booking.Application.DataBase.User.Command.UpdateUserPassword;
using Booking.Application.DataBase.User.Queries.GetAllUser;
using Booking.Application.DataBase.User.Queries.GetUserById;
using Booking.Application.DataBase.User.Queries.GetUserData;
using Booking.Application.Validators.Booking;
using Booking.Application.Validators.Customer;
using Booking.Application.Validators.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserPasswordQuery, GetUserPasswordQuery>();
            
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();

            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            
            services.AddTransient<IGetAllCustomerQuery, GetAllCustomerQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            services.AddTransient<IGetCustomerDocumentQuery, GetCustomerDocumentQuery>();
            #endregion

            #region Booking
            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IGetAllBookingQuery, GetAllBookingQuery>();
            services.AddTransient<IGetBookingDocumentNumberQuery, GetBookingDocumentNumberQuery>();
            services.AddTransient<IGetBookingTypeQuery, GetBookingTypeQuery>();

            #endregion

            #region validators user
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidation>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidation>();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdatePasswordUserValidation>();
            services.AddScoped<IValidator<(string,string)>, GetUserPasswordValidator>();
            #endregion

            #region customers validators
            services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();
            services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidation>();
            #endregion

            #region booking validators
            services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidation>();
            #endregion

            return services;
        }
    }
}
