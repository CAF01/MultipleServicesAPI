namespace MultipleServicesAPP.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MultipleServicesAPP.Entities.Request.Pharmacy;
    using MultipleServicesAPP.Helpers;
    using MultipleServicesAPP.Services.Services;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("Sales")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService salesService;

        public SalesController(ISalesService salesService)
        {
            this.salesService = salesService;
        }

        [HttpGet("get-list-medicaments")]
        public async Task<IActionResult> GetMedicaments()
        {
            var response = await salesService.ReturnListMeds();
            return HelperResult.Result(response);
        }

        [HttpGet("get-by-description")]
        public async Task<IActionResult> GetMedByDescription(string description)
        {
            var response = await salesService.FindMedByDescription(description);
            return HelperResult.Result(response);
        }

        [HttpGet("get-by-presentation")]
        public async Task<IActionResult> GetMedByPresentation(int idCatalog)
        {
            var response = await salesService.ReturnMedByPresentation(idCatalog);
            return HelperResult.Result(response);
        }

        [HttpGet("get-by-expiration-date")]
        public async Task<IActionResult> GetMedByExpiration(DateTime startDate,DateTime finishDate)
        {
            var response = await salesService.FindMedByExpirationDates(startDate, finishDate);
            return HelperResult.Result(response);
        }

        [HttpPost("create-sale")]
        public async Task<IActionResult> CreateSale(InsertSaleRequest insertSaleRequest)
        {
            var response = await salesService.SellMedicament(insertSaleRequest);
            return HelperResult.Result(response);
        }

        [HttpGet("get-short-medicaments")]
        public async Task<IActionResult> GetShortMedDescription()
        {
            var response = await salesService.ReturnShortListMeds();
            return HelperResult.Result(response);
        }

        [HttpGet("get-sales-day")]
        public async Task<IActionResult> GetSalesByDate(DateTime date)
        {
            var response = await salesService.ReturnSalesByDate(date);
            return HelperResult.Result(response);
        }
    }
}
