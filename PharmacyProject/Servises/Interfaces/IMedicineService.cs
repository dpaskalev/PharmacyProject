using PharmacyProject.Data.DataModels;
using PharmacyProject.VewModels;

namespace PharmacyProject.Servises.Interfaces
{
    public interface IMedicineService
    {
        public Task<IEnumerable<MedicineIndexViewModel>> GetIndex(string userId);

        public Task<MedicineViewModel> GetAddModelAsynk();

        public Task AddMedicineAsync(MedicineViewModel viewModel, string userId);

        public Task<MedicineDetailsViewModel> GetDetails(int id);

        public Task AssignMedicineAsync(AddMedicineToPharmacyViewModel model);

        public Task<AddMedicineToPharmacyViewModel> GetAddMedcineToPharmacyViewModelAsync(int id);
    }
}
