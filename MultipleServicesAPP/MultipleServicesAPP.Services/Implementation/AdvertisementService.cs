namespace MultipleServicesAPP.Services.Implementation
{
    using MultipleServicesAPP.Entities.Models.Advertisement;
    using MultipleServicesAPP.Repositories.Services;
    using MultipleServicesAPP.Resources.Cloudinary;
    using MultipleServicesAPP.Resources.Database.Advertisement;
    using MultipleServicesAPP.Services.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository advertisementRepository;

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            this.advertisementRepository = advertisementRepository;
        }
        public async Task<IEnumerable<AdItem>> GetItemsByCategory(int idCategory)
        {
            var items = await advertisementRepository.GetItemsByCategory(idCategory);
            if (items != null)
            {
                foreach (var item in items)
                {
                    switch (item.Tipo)
                    {
                        case "Zapatos":
                            item.imgUrl = CloudinaryResources.CloudinaryURL + CloudinaryResources.Zapatos + item.imgUrl;
                            break;
                        case "Lavadoras":
                            item.imgUrl = CloudinaryResources.CloudinaryURL + CloudinaryResources.Lavadoras + item.imgUrl;
                            break;
                        case "Autos":
                            item.imgUrl = CloudinaryResources.CloudinaryURL + CloudinaryResources.Autos + item.imgUrl;
                            break;
                    }
                }
            }
            return items;
        }

        public async Task<IEnumerable<AdItem>> GetRandomListItems()
        {
            var items = await advertisementRepository.GetRandomListItems();
            if(items!=null)
            {
                foreach (var item in items)
                {
                    switch (item.Tipo)
                    {
                        case "Zapatos":
                            item.imgUrl = CloudinaryResources.CloudinaryURL + CloudinaryResources.Zapatos + item.imgUrl;
                            break;
                        case "Lavadoras":
                            item.imgUrl = CloudinaryResources.CloudinaryURL + CloudinaryResources.Lavadoras + item.imgUrl;
                            break;
                        case "Autos":
                            item.imgUrl = CloudinaryResources.CloudinaryURL + CloudinaryResources.Autos + item.imgUrl;
                            break;
                    }
                }
            }
            
            return items;
        }
    }
}
