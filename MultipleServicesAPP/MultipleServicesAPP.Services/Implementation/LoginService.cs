namespace MultipleServicesAPP.Services.Implementation
{
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Services.Services;

    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _logginRepository;

        public LoginService(ILoginRepository logginRepository)
        {
            this._logginRepository = logginRepository;
        }

        //public Task<bool> GetUserStatus(string user, string password)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<int> ValidateAccount(string user, string password)
        {
            var response = await _logginRepository.ValidateAccount(user,password);
            var Status = false;
            if (response > 0)
            {
                Status = await _logginRepository.GetUserStatus(user, password);
                //3 es Admin
                //2 es Cliente
                return Status ? 3 : 2;
            }
            else
                response = 1; // 1 No existe cuenta
            return response;
        }
    }
}
