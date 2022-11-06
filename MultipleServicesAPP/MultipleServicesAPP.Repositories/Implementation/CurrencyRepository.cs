namespace MultipleServicesAPP.Repositories.Implementation
{
    using MultipleServicesAPP.Entities.Models.Currency;
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Resources.Database.Currency;
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class CurrencyRepository : ICurrencyRepository
    {
        public async Task<Currency> ConvertCurrency(string fromCode, string toCode, int? amount)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(CurrencyResources.baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var Amount = amount != null ? CurrencyResources.amount+amount : "";

                var response = await client.GetAsync(String.Format("{0}{1}{2}{3}{4}", CurrencyResources.from, fromCode, CurrencyResources.to, toCode,Amount));
                if (response.IsSuccessStatusCode)
                {
                    string? response2 = await response.Content.ReadAsStringAsync();
                    Currency? actualCurrency = null;
                    if (!String.IsNullOrEmpty(response2))
                    {
                        actualCurrency = JsonSerializer.Deserialize<Currency>(response2);
                        if (actualCurrency != null && actualCurrency.success)
                        {
                            actualCurrency.result = (float)Math.Round(actualCurrency.result, 2);
                            actualCurrency.info.rate = (float)Math.Round(actualCurrency.info.rate, 2);
                        }
                    }
                    return actualCurrency;
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
