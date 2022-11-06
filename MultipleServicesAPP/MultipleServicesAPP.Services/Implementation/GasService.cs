namespace MultipleServicesAPP.Services.Implementation
{
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Services.Services;

    public class GasService : IGasService
    {
        private readonly IGasRepository gasRepository;

        public GasService(IGasRepository gasRepository)
        {
            this.gasRepository = gasRepository;
        }
        public async Task<string> LookForGasPricesByState(string stateCode)
        {
            return await gasRepository.LookForGasPricesByState(stateCode);
        }

        public async Task<string> LookForGasPricesByStateType(string stateCode, string gasType)
        {
            return await gasRepository.LookForGasPricesByStateType(stateCode, gasType);
        }
    }
}
