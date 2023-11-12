using AutoFixture;
using BasicWebApi_Exam1.Data;
using BasicWebApi_Exam1.Model;
using BasicWebApi_Exam1.Models;
using BasicWebApi_Exam1.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

using Moq;
using System;
using System.Linq;
using Xunit;

namespace BasicWebApi_xUnitTest
{
    public class CompanyServiceTests
    {

        private readonly Mock<ApplicationDbContext> _dbContextMock;
        private readonly CompanyService _companyService;


        public CompanyServiceTests()
        {
            _dbContextMock = new Mock<ApplicationDbContext>();
            _companyService = new CompanyService(_dbContextMock.Object);
        }

        [Fact]
        public async Task CreateCompanyAsync_Should_Save_Company_To_Database()
        {

            
            var company = new Company();

            _dbContextMock.Setup(x => x.Set<Company>()).Returns(Mock.Of<DbSet<Company>>());

            
            await _companyService.CreateCompanyAsync(company);

            
            _dbContextMock.Verify(x => x.Set<Company>(), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
        
        

        [Fact]
        public void DeleteCompany_Should_Delete_Company_From_Database()
        {
            var company = new Company();

            _dbContextMock.Setup(x => x.Set<Company>().Remove(company));

            _companyService.DeleteCompany(company);

            _dbContextMock.Verify(x => x.Set<Company>().Remove(company), Times.Once);
            _dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        
    }
}
