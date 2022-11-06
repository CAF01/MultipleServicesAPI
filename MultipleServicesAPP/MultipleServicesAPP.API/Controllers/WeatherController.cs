using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultipleServicesAPP.Entities.Models.WeatherIO;
using MultipleServicesAPP.Services.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace MultipleServicesAPP.API.Controllers
{
    [SwaggerTag("Weather")]
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet("get-forecast-puebla")]
        public async Task<ForeCastToday> GetForeCastPuebla()
        {
            return await weatherService.GetDailyReportPuebla();
        }

        [HttpGet("get-forecast-four-days")]
        public async Task<ForeCast4Days> GetForeCast4Days(float lat,float lon)
        {
            return await weatherService.GetForeCastReportByLat(lat,lon);
        }
    }
}
