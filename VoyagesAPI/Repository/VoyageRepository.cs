using Microsoft.EntityFrameworkCore;
using VoyagesAPI.Data;
using VoyagesAPI.Entities;
using VoyagesAPI.Interfaces;

namespace VoyagesAPI.Repository
{
    public class VoyageRepository : IVoyageRepo
    {
        private readonly DataContext dataContext;

        public VoyageRepository(DataContext _dataContext)
        {
            this.dataContext = _dataContext;
        }

        public async Task<bool> CreateVoyageAsync(Voyage voyage)
        {
            await dataContext.Voyages.AddAsync(voyage);
            var add = await dataContext.SaveChangesAsync();
            return add > 0;
        }

        public async Task<IEnumerable<Voyage>> GetAllAsync()
        {
            return await dataContext.Voyages.ToListAsync();
        }

        public async Task<Voyage> GetByIdAsync(int id)
        {
            return await dataContext.Voyages.SingleOrDefaultAsync(v => v.VoyageId == id);
        }

        public async Task<bool> UpdateAsync(Voyage voyage)
        {
            dataContext.Voyages.Update(voyage);
            var updated = await dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var check = await GetByIdAsync(id);
            dataContext.Voyages.Remove(check);
            var deleted = await dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
