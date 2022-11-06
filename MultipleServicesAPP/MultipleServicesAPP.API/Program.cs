using Microsoft.Extensions.Configuration;
using MultipleServicesAPP.Entities.Database;
using MultipleServicesAPP.Entities.Models.WeatherIO;
using MultipleServicesAPP.Repositories.Implementation;
using MultipleServicesAPP.Repositories.Services;
using MultipleServicesAPP.Services.Implementation;
using MultipleServicesAPP.Services.Services;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IMapper mapper = mapperConfiguration.CreateMapper();
//services.AddSingleton(mapper);

Dictionary<Database, Func<IDbConnection>> connectionFactory = new()
   {
      { 
        Database.Pharmacy, () => new SqlConnection(configuration.GetConnectionString("DbConnectionPharmacy")) 
      },
      { 
        Database.Advertisement, () => new SqlConnection(configuration.GetConnectionString("DbConnectionAdvertisement")) 
      }
   };

builder.Services.AddSingleton(connectionFactory);
builder.Services.Configure<WeatherbitConfig>(configuration.GetSection("WeatherbitConfig"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("http://localhost:4200", "http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

});


#region AddScopeds
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();

builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();

builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

builder.Services.AddScoped<IGasService, GasService>();
builder.Services.AddScoped<IGasRepository, GasRepository>();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
#endregion

var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Extra
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
