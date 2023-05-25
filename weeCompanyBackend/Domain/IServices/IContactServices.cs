using weeCompanyBackend.Domain.Models;

namespace weeCompanyBackend.Domain.IServices
{
    public interface IContactServices
    {
        Task<List<Contact>> getAllContacts();
        Task<Contact> getContactById(int contactId);
        Task createContact(Contact contact);
        Task updateContact(Contact contact);
        Task deleteContact(int contactId);
    }
}
