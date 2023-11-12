using BasicWebApi_Exam1.Models;
using BasicWebApi_Exam1.Models.DTO;
using BasicWebApi_Exam1.Services.Interfaces;
using BasicWebApi_Exam1.Model;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi_Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;   

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> AddCompany([FromBody] CompanyDTO createCompanyDTO)
        {
            if (ModelState.IsValid)
            {
                var company = new Company
                {
                    CompanyName = createCompanyDTO.CompanyName,
                };

                try
                {
                    await _companyService.CreateCompanyAsync(company);
                    return Ok(company);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error occurred while adding the company: " + ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            var company = await _companyService.GetCompanyByIdAsync(companyId);

            if (company == null)
            {
                return NotFound();
            }

            try
            {
                _companyService.DeleteCompany(company);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Error occurred while deleting the company: " + ex.Message);
            }
        }

        [HttpPut("{companyId}")]
        public async Task<IActionResult> UpdateCompany(int companyId, [FromBody] CompanyDTO updateCompanyDto)
        {
            if (ModelState.IsValid)
            {
                var existingCompany = await _companyService.GetCompanyByIdAsync(companyId);

                if (existingCompany == null)
                {
                    return NotFound();
                }

                existingCompany.CompanyName = updateCompanyDto.CompanyName;

                try
                {
                    _companyService.UpdateCompany(existingCompany);
                    return Ok(existingCompany);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error occurred while updating the company: " + ex.Message);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
