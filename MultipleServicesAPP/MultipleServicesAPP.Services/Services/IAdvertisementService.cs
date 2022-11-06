namespace MultipleServicesAPP.Services.Services
{
    using MultipleServicesAPP.Entities.Models.Advertisement;

    public interface IAdvertisementService
    {
        public Task<IEnumerable<AdItem>> GetRandomListItems();
        public Task<IEnumerable<AdItem>> GetItemsByCategory(int idCategory);
    }
}
