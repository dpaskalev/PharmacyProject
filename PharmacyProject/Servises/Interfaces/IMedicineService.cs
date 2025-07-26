using PharmacyProject.Data.DataModels;
using PharmacyProject.VewModels;

namespace PharmacyProject.Servises.Interfaces
{
    public interface IMedicineService
    {
        public Task<IEnumerable<Medicine>> GetIndex();

        public Task<MedicineViewModel> GetAddModelAsynk();
    }
}
