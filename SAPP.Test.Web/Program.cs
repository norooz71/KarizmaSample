using Karizma.Sample.Persistance;
using Karizma.Sample.Presentation;
using Karizma.Sample.Presentation.Controllers;
using Karizma.Sample.Services;
using Karizma.Sample.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
).AddApplicationPart(typeof(OrderController).Assembly);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddServiceManager();

builder.Services.AddUnitOfWork();

builder.Services.AddDbContext(builder.Configuration);

builder.Services.AddAutoMapperService();

builder.Services.AddLogger();

builder.Services.ConfigurePriceCalculatingSetting(builder.Configuration);

builder.Services.ConfigureValidTime(builder.Configuration);

builder.Services.AddOrderPriceValidation();

builder.Services.AddOrderTimeValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
