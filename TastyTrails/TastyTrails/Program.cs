using BusinessLogic;
using BusinessLogic.Emails;
using DataAccess;
using DataAccess.RepositoryImpementation;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

//Add EF
builder.Services.AddDbContext<TastyTrailsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TastyTrailsConnection")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IUserInfoService, UserInfoService>();
builder.Services.AddTransient<IMenuItemService, MenuItemService>();
builder.Services.AddTransient<IRestaurantService, RestaurantService>();
builder.Services.AddTransient<ISmtpClientService, SmtpClientService>();
builder.Services.AddTransient<IEmailDeliveryService, EmailDeliveryService>();

builder.Services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificationHub>("/TastyTrailsNotification");

app.Run();
