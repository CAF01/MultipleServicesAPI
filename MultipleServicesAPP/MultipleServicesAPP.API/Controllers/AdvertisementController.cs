namespace MultipleServicesAPP.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MultipleServicesAPP.Helpers;
    using MultipleServicesAPP.Services.Services;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("Advertisement")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            this.advertisementService = advertisementService;
        }

        [HttpGet("get-items-randomly")]
        public async Task<IActionResult> GetItemsRandomly()
        {
            var response = await advertisementService.GetRandomListItems();
            return HelperResult.Result(response);
        }

        [HttpGet("get-items-by-category")]
        public async Task<IActionResult> GetItemsByCategory(int idCatalog)
        {
            var response = await advertisementService.GetItemsByCategory(idCatalog);
            return HelperResult.Result(response);
        }

    }
}
