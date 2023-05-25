using weeCompanyBackend.Domain.Models;
using weeCompanyBackend.Controllers;
using weeCompanyBackend.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace weeCompanyBackend.Test
{
    public class ContactControllerTest
    {
        public class ContactControllerTests
        {
            private readonly Mock<IContactServices> _mockService;
            private readonly ContactController _controller;

            public ContactControllerTests()
            {
                _mockService = new Mock<IContactServices>();
                _controller = new ContactController(_mockService.Object);
            }

            [Fact]
            public async Task Get_ReturnsOk_WhenServiceReturnsList()
            {
                // Arrange
                var contacts = new List<Contact>
            {
                new Contact("Company1", "Contact1", "email1@example.com", "1234567890"),
                new Contact("Company2", "Contact2", "email2@example.com", "0987654321")
            };

                _mockService.Setup(service => service.getAllContacts()).ReturnsAsync(contacts);

                // Act
                var result = await _controller.Get();

                // Assert
                var actionResult = Assert.IsType<OkObjectResult>(result);
                var model = Assert.IsAssignableFrom<List<Contact>>(actionResult.Value);
                Assert.Equal(contacts, model);
            }

            [Fact]
            public async Task Get_ReturnsBadRequest_WhenServiceThrowsException()
            {
                // Arrange
                _mockService.Setup(service => service.getAllContacts()).ThrowsAsync(new Exception());

                // Act
                var result = await _controller.Get();

                // Assert
                Assert.IsType<BadRequestObjectResult>(result);
            }

            [Fact]
            public async Task GetContactById_ReturnsOk_WhenServiceReturnsContact()
            {
                // Arrange
                var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");

                _mockService.Setup(service => service.getContactById(It.IsAny<int>())).ReturnsAsync(contact);

                // Act
                var result = await _controller.GetContactById(1);

                // Assert
                var actionResult = Assert.IsType<OkObjectResult>(result);
                var model = Assert.IsAssignableFrom<Contact>(actionResult.Value);
                Assert.Equal(contact, model);
            }

            [Fact]
            public async Task GetContactById_ReturnsBadRequest_WhenServiceThrowsException()
            {
                // Arrange
                _mockService.Setup(service => service.getContactById(It.IsAny<int>())).ThrowsAsync(new Exception());

                // Act
                var result = await _controller.GetContactById(1);

                // Assert
                Assert.IsType<BadRequestObjectResult>(result);
            }

            [Fact]
            public async Task CreateContact_ReturnsOk_WhenServiceCreatesContact()
            {
                // Arrange
                var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");

                _mockService.Setup(service => service.createContact(It.IsAny<Contact>())).Returns(Task.CompletedTask);

                // Act
                var result = await _controller.createContact(contact);

                // Assert
                var actionResult = Assert.IsType<OkObjectResult>(result);
                var model = Assert.IsAssignableFrom<Contact>(actionResult.Value);
                Assert.Equal(contact, model);
            }

            [Fact]
            public async Task CreateContact_ReturnsBadRequest_WhenServiceThrowsException()
            {
                // Arrange
                var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");

                _mockService.Setup(service => service.createContact(It.IsAny<Contact>())).ThrowsAsync(new Exception());

                // Act
                var result = await _controller.createContact(contact);

                // Assert
                Assert.IsType<BadRequestObjectResult>(result);
            }

            [Fact]
            public async Task UpdateContact_ReturnsOk_WhenServiceUpdatesContact()
            {
                // Arrange
                var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");

                _mockService.Setup(service => service.updateContact(It.IsAny<Contact>())).Returns(Task.CompletedTask);

                // Act
                var result = await _controller.updateContact(contact);

                // Assert
                var actionResult = Assert.IsType<OkObjectResult>(result);
                var model = Assert.IsAssignableFrom<Contact>(actionResult.Value);
                Assert.Equal(contact, model);
            }

            [Fact]
            public async Task UpdateContact_ReturnsBadRequest_WhenServiceThrowsException()
            {
                // Arrange
                var contact = new Contact("Company", "Contact", "email@example.com", "1234567890");

                _mockService.Setup(service => service.updateContact(It.IsAny<Contact>())).ThrowsAsync(new Exception());

                // Act
                var result = await _controller.updateContact(contact);

                // Assert
                Assert.IsType<BadRequestObjectResult>(result);
            }

        }
    }
}
