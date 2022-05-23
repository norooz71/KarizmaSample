using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using Karizma.Sample.Contracts.Utilities.Logger;
using Karizma.Sample.Domain.Repositories;
using Karizma.Sample.Persistance.Repositories;
using Karizma.Sample.Presentation.Controllers;
using Karizma.Sample.Services;
using Karizma.Sample.Services.Abstractions;
using Karizma.Sample.Services.Utilities.Logger;
using Karizma.Sample.Web.Middlewares;
using Karizma.Sample.Services.Abstractions.Dtos;
using Karizma.Sample.Presentation.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(OrderController).Assembly);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IServiceManager,ServiceManager>();

builder.Services.AddServiceManager();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

builder.Services.AddDbContext<RepositoryDbContext>(dbBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");

    dbBuilder.UseSqlServer(connectionString);

});
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddSingleton<ILoggerManager,LoggerManager>();

builder.Services.Configure<PriceCalculatingSetting>(builder.Configuration.GetSection("PriceCalculatingSetting"));

builder.Services.Configure<ValidTime>(builder.Configuration.GetSection("ValidTime"));

builder.Services.AddScoped<OrderPriceValidation>();
builder.Services.AddScoped<OrderTimeValidation>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
