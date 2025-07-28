using Microsoft.AspNetCore.Mvc;
using PharmacyProject.Data.DataModels;
using PharmacyProject.VewModels;

namespace PharmacyProject.Servises.Interfaces
{
    public interface IPharmacyService
    {
        public Task<IEnumerable<PharmacyViewModel>> GetPharmaciesAsynk(string userId);

        public PharmacyViewModel GetPharmacyViewModel();

        public Task AddPharamcyToDatabaseAsync(PharmacyViewModel model, string userId);

        public Task<PharmacyDetailsViewModel> GetDetailsAsync(int id);

        public Task<PharmacyDeleteViewModel> GetPharmacyDeleteViewModel(int id);

        public Task Delete(int id);
    }
}
