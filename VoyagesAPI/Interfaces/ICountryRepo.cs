using VoyagesAPI.Entities;

namespace VoyagesAPI.Interfaces
{
    public interface ICountryRepo
    {
        Task<bool> AddCountryAsync(Country country);

        Task<IEnumerable<Country>> GetCountriesAsync();

        Task<Country> GetByIdAsync(int id);

        Task<bool> UpdateCountryAsync(Country country);

        Task<bool> DeleteCountryAsync(int id);
    }
}
