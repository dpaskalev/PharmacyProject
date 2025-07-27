using PharmacyProject.Data.DataModels;
using PharmacyProject.VewModels;

namespace PharmacyProject.Servises.Interfaces
{
    public interface ICartService
    {
        public Task<IEnumerable<CartViewModel>> GetIndexAsync(string userId);
    }
}
