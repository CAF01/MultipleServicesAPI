namespace MultipleServicesAPP.Services.Services
{
    public interface ILoginService
    {
        Task<int> ValidateAccount(string user, string password);
    }
}
