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

         public async void AddCountry(Country country)
        {
            await dataContext.Countries.AddAsync(country);
            await dataContext.SaveChangesAsync();
        }

       
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await dataContext.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            var country = await dataContext.Countries.FirstOrDefaultAsync(c => c.CountryId == id);
            return country;
        }

        public async void UpdateCountry(Country country)
        {
            dataContext.Entry(country).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }

        public async void DeleteCountry(int id)
        {
            dataContext.Remove(id).State = EntityState.Deleted;
            await dataContext.SaveChangesAsync();
        }
    }
}
