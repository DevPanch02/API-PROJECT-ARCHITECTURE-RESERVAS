using AutoMapper;
using Booking.Application.DataBase.Bookings.Command.CreateBooking;
using Booking.Application.DataBase.Customer.Command.CreateCustomer;
using Booking.Application.DataBase.Customer.Command.UpdateCustomer;
using Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Booking.Application.DataBase.Customer.Queries.GetCustomerDocument;
using Booking.Application.DataBase.User.Command.CreateUser;
using Booking.Application.DataBase.User.Command.UpdateUser;
using Booking.Application.DataBase.User.Queries.GetAllUser;
using Booking.Application.DataBase.User.Queries.GetUserById;
using Booking.Application.DataBase.User.Queries.GetUserData;
using Booking.Domain.Entities.Booking;
using Booking.Domain.Entities.Customer;
using Booking.Domain.Entities.Users;

namespace Booking.Application.Configuration
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();

            CreateMap<UserEntity, GetUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserPasswordModel>().ReverseMap();
            //CreateMap<UserEntity, DeleteUserModel>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();

            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerDocumentModel>().ReverseMap();
            #endregion

            #region Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();

            #endregion



        }
    }
}
