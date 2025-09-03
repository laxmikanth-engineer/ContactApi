using ContactAPI.Models;

namespace ContactAPI.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts(bool? isActive);
        Contact? GetContactById(int id);
        Contact AddContact(Contact contact);
        Contact UpdateContact(Contact contact);
        bool DeleteContact(int id);
    }
}
