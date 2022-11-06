namespace MultipleServicesAPP.Repositories.Services
{
    public interface IGasRepository
    {
        public Task<string> LookForGasPricesByState(string stateCode);
        public Task<string> LookForGasPricesByStateType(string stateCode, string gasType);
    }
}
