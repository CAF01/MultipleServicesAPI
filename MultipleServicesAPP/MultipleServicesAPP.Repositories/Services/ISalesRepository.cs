using MultipleServicesAPP.Entities.Models;
using MultipleServicesAPP.Entities.Request.Pharmacy;

namespace MultipleServicesAPP.Repositories.Services
{
    public interface ISalesRepository
    {
        public Task<IEnumerable<MedicamentForList>> ReturnListMeds();
        public Task<IEnumerable<MedicamentForList>> FindMedByDescription(string description);
        public Task<IEnumerable<MedicamentForList>> ReturnMedByPresentation(int idCatalog);
        public Task<IEnumerable<MedicamentForList>> FindMedByExpirationDates(DateTime startDate,DateTime finishDate);
        public Task<int> SellMedicament(InsertSaleRequest insertSaleRequest);
        public Task<IEnumerable<MedicamentForPicker>> ReturnShortListMeds();
        public Task<IEnumerable<MedicamentForSale>> ReturnSalesByDate(DateTime date);
    }
}
