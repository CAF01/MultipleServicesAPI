namespace MultipleServicesAPP.Services.Services
{
    using MultipleServicesAPP.Entities.Models.WeatherIO;

    public interface IWeatherService
    {
        public Task<ForeCastToday> GetDailyReportPuebla();
        public Task<ForeCast4Days> GetForeCastReportByLat(float lat, float lon);
    }
}
