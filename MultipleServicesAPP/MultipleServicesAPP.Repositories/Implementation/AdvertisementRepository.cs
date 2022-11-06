using Dapper;
using MultipleServicesAPP.Entities.Database;
using MultipleServicesAPP.Entities.Models.Advertisement;
using MultipleServicesAPP.Helpers;
using MultipleServicesAPP.Repositories.Services;
using MultipleServicesAPP.Resources.Database.Advertisement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleServicesAPP.Repositories.Implementation
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly IDbConnection _advertisementConnection;

        public AdvertisementRepository(Dictionary<Database, Func<IDbConnection>> connectionFactory)
        {
            if (connectionFactory is null)
            {
                throw new ArgumentNullException(nameof(connectionFactory));
            }
            _advertisementConnection = connectionFactory[Database.Advertisement]();
        }
        public async Task<IEnumerable<AdItem>> GetItemsByCategory(int idCategory)
        {
            try
            {
                _advertisementConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Option, 1);
                parameters.Add(StoredProcedureResources.idCatalog, idCategory);

                var result = await _advertisementConnection.QueryAsync<AdItem>(
                           sql: StoredProcedureResources.stp_admin_advertisement,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                _advertisementConnection?.Close();
            }
        }

        public async Task<IEnumerable<AdItem>> GetRandomListItems()
        {
            try
            {
                _advertisementConnection.Open();
                var parameters = new DynamicParameters();

                var result = await _advertisementConnection.QueryAsync<AdItem>(
                           sql: StoredProcedureResources.stp_admin_advertisement,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                _advertisementConnection?.Close();
            }
        }
    }
}
