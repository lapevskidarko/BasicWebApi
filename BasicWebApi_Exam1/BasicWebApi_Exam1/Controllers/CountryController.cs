using BasicWebApi_Exam1.Models;
using BasicWebApi_Exam1.Models.DTO;
using BasicWebApi_Exam1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi_Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> AddCountry([FromBody] CountryDTO createCountryDTO)
        {
            if (ModelState.IsValid)
            {
                var country = new Country
                {
                    CountryName = createCountryDTO.CountryName,
                };

                await _countryService.CreateCountryAsync(country);
                return Ok(country);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{countryId}")]
        public async Task<IActionResult> DeleteCountry(int countryId)
        {
            var country = await _countryService.GetCountryByIdAsync(countryId);

            if (country == null)
            {
                return NotFound();
            }

            _countryService.DeleteCountry(country);

            return NoContent();
        }

        [HttpPut("{countryId}")]
        public async Task<IActionResult> UpdateCountry(int countryId, [FromBody] CountryDTO updateCountryDto)
        {
            if (ModelState.IsValid)
            {
                var existingCountry = await _countryService.GetCountryByIdAsync(countryId);

                if (existingCountry == null)
                {
                    return NotFound();
                }

                existingCountry.CountryName = updateCountryDto.CountryName;

                _countryService.UpdateCountry(existingCountry);

                return Ok(existingCountry);
            }

            return BadRequest(ModelState);
        }
    }
}
