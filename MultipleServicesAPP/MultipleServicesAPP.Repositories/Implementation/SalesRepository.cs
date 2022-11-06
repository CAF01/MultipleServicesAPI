namespace MultipleServicesAPP.Repositories.Implementation
{
    using Dapper;
    using MultipleServicesAPP.Entities.Database;
    using MultipleServicesAPP.Entities.Models;
    using MultipleServicesAPP.Entities.Request.Pharmacy;
    using MultipleServicesAPP.Helpers;
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Resources.Database.Pharmacy;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    public class SalesRepository : ISalesRepository
    {
        private readonly IDbConnection _pharmacyConnection;

        public SalesRepository(Dictionary<Database, Func<IDbConnection>> connectionFactory)
        {
            if (connectionFactory is null)
            {
                throw new ArgumentNullException(nameof(connectionFactory));
            }
            _pharmacyConnection = connectionFactory[Database.Pharmacy]();
        }
        public async Task<IEnumerable<MedicamentForList>> FindMedByDescription(string description)
        {
            try
            {
                _pharmacyConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Option, 1);
                parameters.Add(StoredProcedureResources.description, description);

                var result = await _pharmacyConnection.QueryAsync<MedicamentForList>(
                    sql: StoredProcedureResources.stp_admin_sales,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                _pharmacyConnection?.Close();
            }
        }

        public async Task<IEnumerable<MedicamentForList>> FindMedByExpirationDates(DateTime startDate, DateTime finishDate)
        {
            try
            {
                _pharmacyConnection.Open();
                var parameters = new DynamicParameters();
                startDate = startDate.Date;
                finishDate = finishDate.Date;
                parameters.Add(StoredProcedureResources.Option, 3);
                parameters.Add(StoredProcedureResources.startDate, startDate);
                parameters.Add(StoredProcedureResources.finishDate, finishDate);

                var result = await _pharmacyConnection.QueryAsync<MedicamentForList>(
                    sql: StoredProcedureResources.stp_admin_sales,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                _pharmacyConnection?.Close();
            }
        }

        public async Task<IEnumerable<MedicamentForList>> ReturnListMeds()
        {
            try
            {
                _pharmacyConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Option, 0);

                var result = await _pharmacyConnection.QueryAsync<MedicamentForList>(
                    sql: StoredProcedureResources.stp_admin_sales,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                _pharmacyConnection?.Close();
            }
        }

        public async Task<IEnumerable<MedicamentForList>> ReturnMedByPresentation(int idCatalog)
        {
            try
            {
                _pharmacyConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Option, 2);
                parameters.Add(StoredProcedureResources.idPresentation, idCatalog);

                var result = await _pharmacyConnection.QueryAsync<MedicamentForList>(
                    sql: StoredProcedureResources.stp_admin_sales,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                _pharmacyConnection?.Close();
            }
        }

        public async Task<IEnumerable<MedicamentForSale>> ReturnSalesByDate(DateTime date)
        {
            try
            {
                _pharmacyConnection.Open();
                var parameters = new DynamicParameters();
                date = date.Date;
                parameters.Add(StoredProcedureResources.Option, 6);
                parameters.Add(StoredProcedureResources.registeredDate, date);

                var result = await _pharmacyConnection.QueryAsync<MedicamentForSale>(
                    sql: StoredProcedureResources.stp_admin_sales,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                _pharmacyConnection?.Close();
            }
        }

        public async Task<IEnumerable<MedicamentForPicker>> ReturnShortListMeds()
        {
            try
            {
                _pharmacyConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Option, 5);

                var result = await _pharmacyConnection.QueryAsync<MedicamentForPicker>(
                    sql: StoredProcedureResources.stp_admin_sales,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                _pharmacyConnection?.Close();
            }
        }

        public async Task<int> SellMedicament(InsertSaleRequest insertSaleRequest)
        {
            try
            {
                _pharmacyConnection.Open();
                var parameters = new DynamicParameters();
                var Today = DateTime.Today.Date;
                parameters.Add(StoredProcedureResources.Option, 4);
                parameters.Add(StoredProcedureResources.registeredDate, Today);
                parameters.Add(StoredProcedureResources.quantity, insertSaleRequest.quantity);
                parameters.Add(StoredProcedureResources.idMed, insertSaleRequest.idItem);

                return await _pharmacyConnection.ExecuteScalarAsync<int>(
                    sql: StoredProcedureResources.stp_admin_sales,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);
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
    }
}
