using BasicWebApi_Exam1.Data;
using BasicWebApi_Exam1.Model;
using BasicWebApi_Exam1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi_Exam1.Services.Implementation
{

    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _dbContext;


        public CompanyService( ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCompanyAsync(Company company)
        {
            await _dbContext.Set<Company>().AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _dbContext.Set<Company>().ToListAsync();

        }

        public void UpdateCompany(Company company)
        {
            _dbContext.Entry(company).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteCompany(Company company)
        {
            _dbContext.Set<Company>().Remove(company);
            _dbContext.SaveChanges();
        }

        public async Task<Company> GetCompanyByIdAsync(int companyId)
        {
            return await _dbContext.Company.FindAsync(companyId);

        }
    }
}
