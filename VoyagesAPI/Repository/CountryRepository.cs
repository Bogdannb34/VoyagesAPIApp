using Microsoft.EntityFrameworkCore;
using VoyagesAPI.Data;
using VoyagesAPI.Entities;
using VoyagesAPI.Interfaces;

namespace VoyagesAPI.Repository
{
    public class CountryRepository : ICountryRepo
    {
        private readonly DataContext dataContext;

        public CountryRepository(DataContext _dataContext)
        {
            this.dataContext = _dataContext;
        }

         public async Task<bool> AddCountryAsync(Country country)
        {
            await dataContext.Countries.AddAsync(country);
            var created = await dataContext.SaveChangesAsync();
            return created > 0;
        }

       
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await dataContext.Countries.ToListAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await dataContext.Countries.SingleOrDefaultAsync(c => c.CountryId == id);
        }

        public async Task<bool> UpdateCountryAsync(Country country)
        {
            dataContext.Countries.Update(country);
            var updated = await dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            var country = await GetByIdAsync(id);
            dataContext.Countries.Remove(country);
            var deleted = await dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
