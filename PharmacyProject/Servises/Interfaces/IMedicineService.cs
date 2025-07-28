using PharmacyProject.Data.DataModels;
using PharmacyProject.VewModels;

namespace PharmacyProject.Servises.Interfaces
{
    public interface IMedicineService
    {
        public Task<IEnumerable<Medicine>> GetIndex();

        public Task<MedicineViewModel> GetAddModelAsynk();

        public Task AddMedicineAsync(MedicineViewModel viewModel);

        public Task<MedicineDetailsViewModel> GetDetails(int id);

        public Task AssignMedicineAsync(AddMedicineToPharmacyViewModel model);

        public Task<AddMedicineToPharmacyViewModel> GetAddMedcineToPharmacyViewModelAsync(int id);
    }
}
