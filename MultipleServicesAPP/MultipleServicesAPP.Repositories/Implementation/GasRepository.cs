namespace MultipleServicesAPP.Repositories.Implementation
{
    using MultipleServicesAPP.Entities.Models.WeatherIO;
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Resources.Database.Gas;

    public class GasRepository : IGasRepository
    {
        public async Task<string> LookForGasPricesByState(string stateCode)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GasResources.baseURL);
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/html"));
                var response = await client.GetAsync(GasResources.plusUrl + GasResources.state+stateCode);
                if (response.IsSuccessStatusCode)
                {
                    return GasResources.baseURL+GasResources.plusUrl + GasResources.state + stateCode;
                }
                else
                    return null;
                //string sResponse;
                //if (response.IsSuccessStatusCode)
                //{
                //    Stream? response2 = await response.Content.ReadAsStreamAsync();
                //    using (StreamReader responseReader = new StreamReader(response2))
                //    {
                //        sResponse = responseReader.ReadToEnd();
                //    }
                //    return sResponse;
                //}
                //else
                //    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> LookForGasPricesByStateType(string stateCode, string gasType)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GasResources.baseURL);

                var response = await client.GetAsync(GasResources.plusUrl+GasResources.state + stateCode+GasResources.type+gasType);
                if (response.IsSuccessStatusCode)
                {
                    return GasResources.baseURL + GasResources.plusUrl + GasResources.state + stateCode + GasResources.type + gasType;
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
