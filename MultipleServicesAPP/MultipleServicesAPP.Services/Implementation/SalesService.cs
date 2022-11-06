namespace MultipleServicesAPP.Services.Implementation
{
    using MultipleServicesAPP.Entities.Models;
    using MultipleServicesAPP.Entities.Request.Pharmacy;
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Services.Services;

    public class SalesService : ISalesService
    {
        private readonly ISalesRepository salesRepository;

        public SalesService(ISalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }
        public async Task<IEnumerable<MedicamentForList>> FindMedByDescription(string description)
        {
            return await salesRepository.FindMedByDescription(description);
        }

        public async Task<IEnumerable<MedicamentForList>> FindMedByExpirationDates(DateTime startDate, DateTime finishDate)
        {
            return await salesRepository.FindMedByExpirationDates(startDate, finishDate);
        }

        public async Task<IEnumerable<MedicamentForList>> ReturnListMeds()
        {
            return await salesRepository.ReturnListMeds();
        }

        public async Task<IEnumerable<MedicamentForList>> ReturnMedByPresentation(int idCatalog)
        {
            return await salesRepository.ReturnMedByPresentation(idCatalog);
        }

        public async Task<IEnumerable<MedicamentForSale>> ReturnSalesByDate(DateTime date)
        {
            return await salesRepository.ReturnSalesByDate(date);
        }

        public async Task<IEnumerable<MedicamentForPicker>> ReturnShortListMeds()
        {
            return await salesRepository.ReturnShortListMeds();
        }

        public async Task<int> SellMedicament(InsertSaleRequest insertSaleRequest)
        {
            return await salesRepository.SellMedicament(insertSaleRequest);
        }
    }
}
