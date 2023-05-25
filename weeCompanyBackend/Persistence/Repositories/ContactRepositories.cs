using Microsoft.EntityFrameworkCore;
using weeCompanyBackend.Domain.IRepositories;
using weeCompanyBackend.Domain.Models;
using weeCompanyBackend.Persistence.Context;

namespace weeCompanyBackend.Repositories
{
    public class ContactRepositories : IContactRepositories
    {
        private readonly AppDbContext _context;
        public ContactRepositories(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Contact>> getAllContacts()
        {
            var listContacts = await _context.Contact.ToListAsync();
            return listContacts;
        }

        public async Task<Contact> getContactById(int contactId)
        {
            var contactFound = await _context.Contact.FirstOrDefaultAsync( contact => contact.Id == contactId);

            if (contactFound == null) throw new Exception("No existe un contacto con el id " + contactId);

            return contactFound;
        }

        public async Task deleteContact(int contactId)
        {
            var contactFound = await getContactById(contactId);
            _context.Contact.Remove(contactFound);
            await _context.SaveChangesAsync();
        }


        public async Task createContact(Contact contact)
        {
            _context.Contact.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task updateContact(Contact contact)
        {
            _context.Contact.Update(contact);
            await _context.SaveChangesAsync();
        }
    }
}
