namespace MultipleServicesAPP.Services.Services
{
    using MultipleServicesAPP.Entities.Models;
    using MultipleServicesAPP.Entities.Request.Pharmacy;
    public interface ISalesService
    {
        public Task<IEnumerable<MedicamentForList>> ReturnListMeds();
        public Task<IEnumerable<MedicamentForList>> FindMedByDescription(string description);
        public Task<IEnumerable<MedicamentForList>> ReturnMedByPresentation(int idCatalog);
        public Task<IEnumerable<MedicamentForList>> FindMedByExpirationDates(DateTime startDate, DateTime finishDate);
        public Task<int> SellMedicament(InsertSaleRequest insertSaleRequest);
        public Task<IEnumerable<MedicamentForPicker>> ReturnShortListMeds();
        public Task<IEnumerable<MedicamentForSale>> ReturnSalesByDate(DateTime date);
    }
}
