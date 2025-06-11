using Booking.Api;
using Booking.Application;
using Booking.Common;
using Booking.External;
using Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

// Add services to the container.

var app = builder.Build();




// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();
app.Run();


