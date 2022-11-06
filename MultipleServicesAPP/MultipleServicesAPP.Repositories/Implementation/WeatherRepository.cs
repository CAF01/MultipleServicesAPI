namespace MultipleServicesAPP.Repositories.Implementation
{
    using Microsoft.Extensions.Options;
    using MultipleServicesAPP.Entities.Models.WeatherIO;
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Resources.Database.WeatherIO;
    using System.Text.Json;

    public class WeatherRepository : IWeatherRepository
    {
        private readonly string apiKey;
        public WeatherRepository(IOptions<WeatherbitConfig> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            apiKey = options.Value.apiKey;
        }

        public async Task<ForeCastToday> GetDailyReportPuebla()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress=new Uri(WeatherResources.baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(WeatherResources.consumingDailyReportPuebla+apiKey);
                if (response.IsSuccessStatusCode)
                {
                    string? response2 = await response.Content.ReadAsStringAsync();
                    ForeCastToday? foreCastToday=null;
                    if (!String.IsNullOrEmpty(response2))
                        foreCastToday = JsonSerializer.Deserialize<ForeCastToday>(response2);
                    return foreCastToday;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ForeCast4Days> GetForeCastReportByLat(float lat, float lon)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(WeatherResources.baseURL);

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string parameters = String.Format(WeatherResources.concatenation,lat,lon,apiKey);

                var response = await client.GetAsync(WeatherResources.consumingForHours+parameters);
                if (response.IsSuccessStatusCode)
                {
                    string? response2 = await response.Content.ReadAsStringAsync();
                    ForeCast4Days? foreCast4Days = null;
                    if (!String.IsNullOrEmpty(response2))
                        foreCast4Days = JsonSerializer.Deserialize<ForeCast4Days>(response2);
                    return foreCast4Days;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
