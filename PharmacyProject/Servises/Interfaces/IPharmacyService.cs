using PharmacyProject.Data.DataModels;
using PharmacyProject.VewModels;

namespace PharmacyProject.Servises.Interfaces
{
    public interface IPharmacyService
    {
        public Task<IEnumerable<PharmacyViewModel>> GetPharmaciesAsynk();

        public PharmacyViewModel GetPharmacyViewModel();
    }
}
