using VoyagesAPI.Entities;

namespace VoyagesAPI.Interfaces
{
    public interface IShipRepo
    {
        Task<bool> AddShipAsync(Ship ship);

        Task<IEnumerable<Ship>> GetAllAsync();

        Task<Ship> GetByIdAsync(int id);

        Task<bool> UpdateShipAsync(Ship ship);

        Task<bool> DeleteShipAsync(int id);
    }
}
