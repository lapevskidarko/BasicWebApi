using BasicWebApi_Exam1.Models;

namespace BasicWebApi_Exam1.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateContactAsync(Contact contact);
        void DeleteContact(Contact contact);
        Task<List<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int contactId);
        void UpdateContact(Contact contact);
        Task<List<Contact>> FilterContactsAsync(int? countryId, int? companyId);
    }
}
