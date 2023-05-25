using weeCompanyBackend.Domain.IRepositories;
using weeCompanyBackend.Domain.IServices;
using weeCompanyBackend.Domain.Models;

namespace weeCompanyBackend.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepositories _contactRepositories;

        public ContactServices (IContactRepositories contactRepositories)
        {
            _contactRepositories = contactRepositories;
        }

        public async Task<List<Contact>> getAllContacts()
        {
            var ListContact = await _contactRepositories.getAllContacts();
            return ListContact;
        }

        public async Task<Contact> getContactById(int contactId)
        {
            var Contact = await _contactRepositories.getContactById(contactId);
            return Contact;
        }
        public Task deleteContact(int contactId)
        {
            return _contactRepositories.deleteContact(contactId);
        }

        public async Task createContact(Contact contact)
        {
            await _contactRepositories.createContact(contact);
        }

        public async Task updateContact(Contact contact)
        {
            await _contactRepositories.updateContact(contact);
        }
    }
}
