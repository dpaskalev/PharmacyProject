using Microsoft.AspNetCore.Mvc;
using PharmacyProject.Data.DataModels;
using PharmacyProject.VewModels;

namespace PharmacyProject.Servises.Interfaces
{
    public interface IPharmacyService
    {
        public Task<IEnumerable<PharmacyViewModel>> GetPharmaciesAsynk();

        public PharmacyViewModel GetPharmacyViewModel();

        public Task AddPharamcyToDatabaseAsync(PharmacyViewModel model);

        public Task<PharmacyDetailsViewModel> GetDetailsAsync(int id);
    }
}
