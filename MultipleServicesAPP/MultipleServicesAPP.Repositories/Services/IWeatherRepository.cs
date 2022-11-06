namespace MultipleServicesAPP.Repositories.Services
{
    using MultipleServicesAPP.Entities.Models.WeatherIO;

    public interface IWeatherRepository
    {
        public Task<ForeCastToday> GetDailyReportPuebla();
        public Task<ForeCast4Days> GetForeCastReportByLat(float lat,float lon);
    }
}
