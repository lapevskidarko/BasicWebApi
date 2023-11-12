using BasicWebApi_Exam1.Model;

namespace BasicWebApi_Exam1.Services.Interfaces
{
    public interface ICompanyService
    {
        Task CreateCompanyAsync(Company company);
        Task<List<Company>> GetAllCompaniesAsync();
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        Task<Company> GetCompanyByIdAsync(int companyId);
    }
}
