using MultipleServicesAPP.Entities.Models.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleServicesAPP.Repositories.Services
{
    public interface IAdvertisementRepository
    {
        public Task<IEnumerable<AdItem>> GetRandomListItems();
        public Task<IEnumerable<AdItem>> GetItemsByCategory(int idCategory);
    }
}
