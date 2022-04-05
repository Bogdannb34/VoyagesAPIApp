using VoyagesAPI.Entities;

namespace VoyagesAPI.Interfaces
{
    public interface IPortRepo
    {

        Task<bool> AddPortAsync(Port port);

        Task<IEnumerable<Port>> GetAllAsync();

        Task<Port> GetByIdAsync(int id);

        Task<bool> UpdatePortAsync(Port port);

        Task<bool> DeleteAsync(int id);
    }
}
