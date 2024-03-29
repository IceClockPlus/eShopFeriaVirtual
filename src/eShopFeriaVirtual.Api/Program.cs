using eShopFeriaVirtual.Api.Middlewares;
using eShopFeriaVirtual.Application;
using eShopFeriaVirtual.Infrastructure;
using eShopFeriaVirtual.Infrastructure.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDatabaseSetting>(builder.Configuration.GetSection("MongoDatabaseSetting"));
// Add services to the container.
builder.Services.AddApplication()
                .AddInfrastructure();

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
