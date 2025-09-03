using ContactAPI.Data;
using ContactAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace ContactAPI.Services
{
    public class ContactDbService : IContactDbService
    {
        private readonly ContactDbContext _context;
        public ContactDbService(ContactDbContext contactDb)
        {

            _context = contactDb;
        }

        public async Task<List<Contact>> GetAllContactsAsync(bool? isActive)
        {
            if (isActive == null) { return await _context.Contacts.ToListAsync(); }

            return await _context.Contacts.Where(obj => obj.IsActive).ToListAsync();
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Contact?> AddContactAsync(Contact contact)
        {
            var AddContact = new Contact()
            {

                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone,
                IsActive = contact.IsActive
            };

            _context.Contacts.Add(contact);
            var result = await _context.SaveChangesAsync();

            return result >= 0 ? AddContact : null;
        }

        public async Task<Contact?> UpdateContactAsync(Contact contact)
        {
            var existContact = await _context.Contacts.FirstOrDefaultAsync(index => index.Id == contact.Id);

            if (existContact != null)
            {


                existContact.FirstName = contact.FirstName;
                existContact.LastName = contact.LastName;
                existContact.Email = contact.Email;
                existContact.Phone = contact.Phone;
                existContact.IsActive = contact.IsActive;

                var result = await _context.SaveChangesAsync();

                return result >= 0 ? existContact : null;
            }

            return null;
        }
        public async Task<bool> DeleteContactAsync(int id)
        {
            var existContact = await _context.Contacts.FirstOrDefaultAsync(index => index.Id == id);

            if (existContact != null)
            {
                var result = await _context.SaveChangesAsync();

                return result >= 0;
            }
            return false;
        }
    }
}
