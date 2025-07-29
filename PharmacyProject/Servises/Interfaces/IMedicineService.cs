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

        public Task Delete(int id);

        public Task<MedicineDeleteViewModel> GetMedicineDeleteViewModel(int id);

        public Task<MedicineSearchViewModel> GetSearchViewModel();

        public Task<IEnumerable<MedicineIndexViewModel>> GetSearchResultAsync(MedicineSearchViewModel model, string userId);
    }
}
