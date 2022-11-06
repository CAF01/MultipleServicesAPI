namespace MultipleServicesAPP.Services.Implementation
{
    using MultipleServicesAPP.Entities.Models.WeatherIO;
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Services.Services;

    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            this.weatherRepository = weatherRepository;
        }
        public async Task<ForeCastToday> GetDailyReportPuebla()
        {
            return await this.weatherRepository.GetDailyReportPuebla();
        }

        public async Task<ForeCast4Days> GetForeCastReportByLat(float lat, float lon)
        {
            return await this.weatherRepository.GetForeCastReportByLat(lat,lon);
        }
    }
}
