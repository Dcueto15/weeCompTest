using Microsoft.EntityFrameworkCore;
using weeCompanyBackend.Domain.Models;
using weeCompanyBackend.Persistence.Context;
using weeCompanyBackend.Repositories;

namespace weeCompany.Tests
{
    public class ContactRepositoriesTests
    {
        private AppDbContext _context;
        private ContactRepositories _repository;

        public ContactRepositoriesTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _repository = new ContactRepositories(_context);
        }

        [Fact]
        public async Task GetAllContacts_ReturnsAllContacts()
        {
            // Arrange
            var contacts = new List<Contact>
            {
                new Contact("Company1", "Contact1", "email1@example.com", "1234567890"),
                new Contact("Company2", "Contact2", "email2@example.com", "0987654321")
            };
            _context.Contact.AddRange(contacts);
            _context.SaveChanges();

            // Act
            var result = await _repository.getAllContacts();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(contacts[0], result);
            Assert.Contains(contacts[1], result);
        }

        [Fact]
        public async Task GetContactById_ReturnsContact()
        {
            // Arrange
            var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");
            _context.Contact.Add(contact);
            _context.SaveChanges();

            // Act
            var result = await _repository.getContactById(contact.Id);

            // Assert
            Assert.Equal(contact, result);
        }

        [Fact]
        public async Task CreateContact_AddsContactToDatabase()
        {
            // Arrange
            var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");

            // Act
            await _repository.createContact(contact);

            // Assert
            Assert.Contains(contact, _context.Contact);
        }

        [Fact]
        public async Task UpdateContact_UpdatesContactInDatabase()
        {
            // Arrange
            var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");
            _context.Contact.Add(contact);
            _context.SaveChanges();
            contact.NameCompany = "UpdatedCompany";

            // Act
            await _repository.updateContact(contact);

            // Assert
            Assert.Equal("UpdatedCompany", _context.Contact.First().NameCompany);
        }

        [Fact]
        public async Task DeleteContact_DeletesContactFromDatabase()
        {
            // Arrange
            var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");
            _context.Contact.Add(contact);
            _context.SaveChanges();

            // Act
            await _repository.deleteContact(contact.Id);

            // Assert
            Assert.Empty(_context.Contact);
        }
    }
}
