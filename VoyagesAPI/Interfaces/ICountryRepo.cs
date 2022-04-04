using VoyagesAPI.Entities;

namespace VoyagesAPI.Interfaces
{
    public interface ICountryRepo
    {
        void AddCountry(Country country);

        Task<IEnumerable<Country>> GetCountriesAsync();

        Task<Country> GetCountryById(int id);

        void UpdateCountry(Country country);

        void DeleteCountry(int id);
    }
}
