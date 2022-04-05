using VoyagesAPI.Entities;

namespace VoyagesAPI.Interfaces
{
    public interface IVoyageRepo
    {
        Task<bool> CreateVoyageAsync(Voyage voyage);

        Task<IEnumerable<Voyage>> GetAllAsync();

        Task<Voyage> GetByIdAsync(int id);

        Task<bool> UpdateAsync(Voyage voyage);

        Task<bool> DeleteAsync(int id);
    }
}
