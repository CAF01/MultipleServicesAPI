namespace MultipleServicesAPP.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MultipleServicesAPP.Helpers;
    using MultipleServicesAPP.Services.Services;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("Login")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService logginService)
        {
            this._loginService = logginService;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string nombre,string password)
        {
            var response = await _loginService.ValidateAccount(nombre,password);
            return HelperResult.Result(response);
        }
    }
}
