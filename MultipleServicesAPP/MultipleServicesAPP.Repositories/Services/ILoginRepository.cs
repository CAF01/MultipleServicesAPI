namespace MultipleServicesAPP.Repositories.Services
{
    public interface ILoginRepository
    {
        Task<int> ValidateAccount(string user,string password);
        Task<bool> GetUserStatus(string user, string password);
    }
}
