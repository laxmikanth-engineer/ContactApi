using ContactAPI.Models;

namespace ContactAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts;

        public ContactService()
        {
            _contacts = new List<Contact>()
            {
                new Contact(){ Id = 1, FirstName = "Laxmi Kanth", LastName = "Munagala", Email = "laxmikanth.rao@gmail.com", Phone = "8074109898", IsActive = true },
                new Contact(){ Id = 3, FirstName = "Akshitha", LastName = "Munagala", Email = "akshitha.rao@gmail.com", Phone = "8074109114", IsActive = true },
                new Contact(){ Id = 4, FirstName = "Akanksha", LastName = "Munagala", Email = "akanksha.rao@gmail.com", Phone = "8074109115", IsActive = true },
                new Contact(){ Id = 5, FirstName = "Rahul", LastName = "Verma", Email = "rahul.verma@example.com", Phone = "9123456780", IsActive = true },
                new Contact(){ Id = 6, FirstName = "Sneha", LastName = "Patel", Email = "sneha.patel@example.com", Phone = "9123456781", IsActive = false },
                new Contact(){ Id = 7, FirstName = "Arjun", LastName = "Reddy", Email = "arjun.reddy@example.com", Phone = "9123456782", IsActive = true },
                new Contact(){ Id = 8, FirstName = "Meena", LastName = "Kaur", Email = "meena.kaur@example.com", Phone = "9123456783", IsActive = true },
                new Contact(){ Id = 9, FirstName = "Karthik", LastName = "Sharma", Email = "karthik.sharma@example.com", Phone = "9123456784", IsActive = false },
                new Contact(){ Id = 10, FirstName = "Pooja", LastName = "Iyer", Email = "pooja.iyer@example.com", Phone = "9123456785", IsActive = true }

            };
        }
        public Contact AddContact(Contact _contact)
        {
            var contact = new Contact()
            {
                Id = _contacts.Max(c => c.Id) + 1,
                FirstName = _contact.FirstName,
                LastName = _contact.LastName,
                Email = _contact.Email,
                Phone = _contact.Phone,
                IsActive = _contact.IsActive
            };

            _contacts.Add(contact);

            return contact;
        }

        public Contact? UpdateContact(Contact contact)
        {
            var existContact = _contacts.FindIndex(index => index.Id == contact.Id);

            if (existContact > 0)
            {
                var _contact = _contacts[existContact];

                _contact.FirstName = contact.FirstName;
                _contact.LastName = contact.LastName;
                _contact.Email = contact.Email;
                _contact.Phone = contact.Phone;
                _contact.IsActive = contact.IsActive;

                _contacts[existContact] = contact;

                return contact;
            }
            else
                return null;
        }

        public bool DeleteContact(int id)
        {
            var existContact = _contacts.FindIndex(index => index.Id == id);

            if (existContact > 0)
            {
                _contacts.RemoveAt(existContact);
            }

            return existContact >= 0;
        }

        public List<Contact> GetAllContacts(bool? isActive)
        {
            return isActive == null ? _contacts : _contacts.Where(c => c.IsActive == isActive).ToList();
        }

        public Contact? GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }


    }
}
