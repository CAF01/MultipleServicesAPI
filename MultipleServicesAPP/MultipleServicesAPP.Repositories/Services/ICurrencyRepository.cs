using MultipleServicesAPP.Entities.Models.Currency;

namespace MultipleServicesAPP.Repositories.Services
{
    public interface ICurrencyRepository
    {
        public Task<Currency> ConvertCurrency(string fromCode, string toCode,int? amount);
    }
}
