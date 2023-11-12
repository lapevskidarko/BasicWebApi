using BasicWebApi_Exam1.Data;
using BasicWebApi_Exam1.Model;
using BasicWebApi_Exam1.Models;
using BasicWebApi_Exam1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi_Exam1.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateContactAsync(Contact contact)
        {
            await _dbContext.Set<Contact>().AddAsync(contact);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteContact(Contact contact)
        {
            _dbContext.Set<Contact>().Remove(contact);
            _dbContext.SaveChanges();
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _dbContext.Set<Contact>().Include(c => c.Company).Include(c => c.Country).ToListAsync();

        }

        public async Task<Contact> GetContactByIdAsync(int contactId)
        {
            return await _dbContext.Contact.FindAsync(contactId);
        }

        public void UpdateContact(Contact contact)
        {
            _dbContext.Contact.Update(contact);
            _dbContext.SaveChanges();
        }

        public async Task<List<Contact>> FilterContactsAsync(int? countryId, int? companyId)
        {
            IQueryable<Contact> query = _dbContext.Set<Contact>()
                .Include(c => c.Company)
                .Include(c => c.Country);

            if (countryId.HasValue)
            {
                query = query.Where(contact => contact.CountryId == countryId.Value);
            }

            if (companyId.HasValue)
            {
                query = query.Where(contact => contact.CompanyId == companyId.Value);
            }

            return await query.ToListAsync();
        }
    }
}
