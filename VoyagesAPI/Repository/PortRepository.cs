using Microsoft.EntityFrameworkCore;
using VoyagesAPI.Data;
using VoyagesAPI.Entities;
using VoyagesAPI.Interfaces;

namespace VoyagesAPI.Repository
{
    public class PortRepository: IPortRepo
    {
        private readonly DataContext dataContext;

        public PortRepository(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public async Task<bool> AddPortAsync(Port port)
        {
            await dataContext.Ports.AddAsync(port);
            var created = await dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<IEnumerable<Port>> GetAllAsync()
        {
            return await dataContext.Ports.ToListAsync();
        }

        public async Task<Port> GetByIdAsync(int id)
        {
            return await dataContext.Ports.SingleOrDefaultAsync(p => p.PortId == id);
        }

        public async Task<bool> UpdatePortAsync(Port port)
        {
            dataContext.Ports.Update(port);
            var updated = await dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var port = await GetByIdAsync(id);
            dataContext.Ports.Remove(port);
            var deleted = await dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
