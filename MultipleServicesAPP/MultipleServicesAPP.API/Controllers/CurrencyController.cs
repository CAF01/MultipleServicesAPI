namespace MultipleServicesAPP.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MultipleServicesAPP.Helpers;
    using MultipleServicesAPP.Services.Services;
    using Swashbuckle.AspNetCore.Annotations;
    [SwaggerTag("Currency")]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetConvertedCurrency(string fromCode,string toCode, int? amount)
        {
            var result = await currencyService.ConvertCurrency(fromCode, toCode,amount);
            return HelperResult.Result(result);
        }
    }
}
