namespace MultipleServicesAPP.Services.Implementation
{
    using MultipleServicesAPP.Entities.Models.Currency;
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Services.Services;
    using System.Threading.Tasks;

    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }
        public async Task<Currency> ConvertCurrency(string fromCode, string toCode,int? amount)
        {
            return await currencyRepository.ConvertCurrency(fromCode, toCode,amount);
        }
    }
}
