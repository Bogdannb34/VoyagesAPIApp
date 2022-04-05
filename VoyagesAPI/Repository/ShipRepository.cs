using Microsoft.EntityFrameworkCore;
using VoyagesAPI.Data;
using VoyagesAPI.Entities;
using VoyagesAPI.Interfaces;

namespace VoyagesAPI.Repository
{
    public class ShipRepository : IShipRepo
    {
        private readonly DataContext dataContext;

        public ShipRepository(DataContext _dataContext)
        {
            this.dataContext = _dataContext;
        }

        public async Task<bool> AddShipAsync(Ship ship)
        {
            await dataContext.Ships.AddAsync(ship);
            var added = await dataContext.SaveChangesAsync();
            return added > 0;
        }

        public async Task<IEnumerable<Ship>> GetAllAsync()
        {
            return await dataContext.Ships.ToListAsync();
        }

        public async Task<Ship> GetByIdAsync(int id)
        {
            return await dataContext.Ships.SingleOrDefaultAsync(s => s.ShipId == id);
        }

        public async Task<bool> UpdateShipAsync(Ship ship)
        {
            dataContext.Ships.Update(ship);
            var edited = await dataContext.SaveChangesAsync();
            return edited > 0;
        }

        public async Task<bool> DeleteShipAsync(int id)
        {
            var ship = await GetByIdAsync(id);
            dataContext.Ships.Remove(ship);
            var del = await dataContext.SaveChangesAsync();
            return del > 0;
        }
    }
}
