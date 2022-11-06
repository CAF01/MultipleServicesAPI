namespace MultipleServicesAPP.Repositories.Implementation
{
    using Dapper;
    using MultipleServicesAPP.Entities.Database;
    using MultipleServicesAPP.Helpers;
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Resources.Database.Pharmacy;
    using System.Data;

    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnection _pharmacyConnection;

        public LoginRepository(Dictionary<Database, Func<IDbConnection>> connectionFactory)
        {
            if (connectionFactory is null)
            {
                throw new ArgumentNullException(nameof(connectionFactory));
            }
            _pharmacyConnection = connectionFactory[Database.Pharmacy]();
        }

        public async Task<int> ValidateAccount(string user, string password)
        {
            try
            {
                _pharmacyConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.username, user);
                parameters.Add(StoredProcedureResources.password, password);

                return await _pharmacyConnection.ExecuteScalarAsync<int>(
                           sql: StoredProcedureResources.stp_admin_users,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
            }
            catch
            {
                return 0;
            }
            finally
            {
                _pharmacyConnection?.Close();
            }
        }


        public async Task<bool> GetUserStatus(string user,string password)
        {
            try
            {
                _pharmacyConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Option, 1);
                parameters.Add(StoredProcedureResources.username, user);
                parameters.Add(StoredProcedureResources.password, password);

                return await _pharmacyConnection.ExecuteScalarAsync<bool>(
                           sql: StoredProcedureResources.stp_admin_users,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
            }
            catch
            {
                return false;
            }
            finally
            {
                _pharmacyConnection?.Close();
            }
        }
    }
}
