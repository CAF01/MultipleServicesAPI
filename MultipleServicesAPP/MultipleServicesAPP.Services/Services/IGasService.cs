namespace MultipleServicesAPP.Services.Services
{
    public interface IGasService
    {
        public Task<string> LookForGasPricesByState(string stateCode);
        public Task<string> LookForGasPricesByStateType(string stateCode, string gasType);
    }
}
