namespace MultipleServicesAPP.Services.Services
{
    using MultipleServicesAPP.Entities.Models.Currency;
    
    public interface ICurrencyService
    {
        public Task<Currency> ConvertCurrency(string fromCode, string toCode, int? amount);
    }
}
