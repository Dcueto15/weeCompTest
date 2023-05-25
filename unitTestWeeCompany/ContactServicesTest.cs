using Moq;
using weeCompanyBackend.Domain.IRepositories;
using weeCompanyBackend.Domain.Models;
using weeCompanyBackend.Services;

namespace weeCompany.Tests
{
    public class ContactServicesTests
    {
        private readonly Mock<IContactRepositories> _mockRepo;
        private readonly ContactServices _service;

        public ContactServicesTests()
        {
            _mockRepo = new Mock<IContactRepositories>();
            _service = new ContactServices(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllContacts_ReturnsList_WhenRepoReturnsList()
        {
            // Arrange
            var contacts = new List<Contact>
            {
                new Contact("Company1", "Contact1", "email1@example.com", "1234567890"),
                new Contact("Company2", "Contact2", "email2@example.com", "0987654321")
            };

            _mockRepo.Setup(repo => repo.getAllContacts()).ReturnsAsync(contacts);

            // Act
            var result = await _service.getAllContacts();

            // Assert
            Assert.Equal(contacts, result);
        }

        [Fact]
        public async Task GetContactById_ReturnsContact_WhenRepoReturnsContact()
        {
            // Arrange
            var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");

            _mockRepo.Setup(repo => repo.getContactById(It.IsAny<int>())).ReturnsAsync(contact);

            // Act
            var result = await _service.getContactById(1);

            // Assert
            Assert.Equal(contact, result);
        }

        [Fact]
        public async Task CreateContact_ReturnsWhenRepoCreates()
        {
            // Arrange
            var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");

            _mockRepo.Setup(repo => repo.createContact(It.IsAny<Contact>())).Returns(Task.CompletedTask);

            // Act
            await _service.createContact(contact);

            // Assert
            _mockRepo.Verify(repo => repo.createContact(It.IsAny<Contact>()), Times.Once);
        }

        [Fact]
        public async Task UpdateContact_ReturnsWhenRepoUpdates()
        {
            // Arrange
            var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");

            _mockRepo.Setup(repo => repo.updateContact(It.IsAny<Contact>())).Returns(Task.CompletedTask);

            // Act
            await _service.updateContact(contact);

            // Assert
            _mockRepo.Verify(repo => repo.updateContact(It.IsAny<Contact>()), Times.Once);
        }

        [Fact]
        public async Task DeleteContact_ReturnsWhenRepoDeletes()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.deleteContact(It.IsAny<int>())).Returns(Task.CompletedTask);

            // Act
            await _service.deleteContact(1);

            // Assert
            _mockRepo.Verify(repo => repo.deleteContact(It.IsAny<int>()), Times.Once);
        }
    }
}
