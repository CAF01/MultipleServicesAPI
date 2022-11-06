namespace MultipleServicesAPP.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MultipleServicesAPP.Helpers;
    using MultipleServicesAPP.Services.Services;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("Gas")]
    [Route("api/[controller]")]
    [ApiController]
    public class GasController : ControllerBase
    {
        private readonly IGasService gasService;

        public GasController(IGasService gasService)
        {
            this.gasService = gasService;
        }
        [HttpGet("get-by-state")]
        public async Task<IActionResult> GetInfoGasByState(string stateCode)
        {
            var result = await gasService.LookForGasPricesByState(stateCode);
            return HelperResult.Result(result);
        }

        [HttpGet("get-by-state-type")]
        public async Task<IActionResult> GetInfoGasByStateAndType(string stateCode,string gasType)
        {
            var result = await gasService.LookForGasPricesByStateType(stateCode,gasType);
            return HelperResult.Result(result);
        }
    }
}
