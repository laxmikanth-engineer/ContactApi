using ContactAPI.Models;

namespace ContactAPI.Services
{
    public interface IContactDbService
    {
        Task<List<Contact>> GetAllContactsAsync(bool? isActive);
        Task<Contact?> GetContactByIdAsync(int id);
        Task<Contact?> AddContactAsync(Contact contact);
        Task<Contact?> UpdateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
