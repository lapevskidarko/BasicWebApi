using BasicWebApi_Exam1.Models;

namespace BasicWebApi_Exam1.Services.Interfaces
{
    public interface ICountryService
    {
        Task CreateCountryAsync(Country country);
        Task<List<Country>> GetAllCountriesAsync();
        void UpdateCountry(Country country);
        void DeleteCountry(Country country);
        Task<Country> GetCountryByIdAsync(int countryId);
    }
}
