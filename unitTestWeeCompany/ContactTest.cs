using System.ComponentModel.DataAnnotations;
using weeCompanyBackend.Domain.Models;

namespace weeCompanyBackend.Test
{
    public class ContactTests
    {
        [Fact]
        public void Contact_Validate_InvalidEmail_ThrowsException()
        {
            // Arrange
            var contact = new Contact("CompanyName", "ContactName", "invalidEmail", "1234567890");

            var context = new ValidationContext(contact);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(contact, context, result, true);

            // Assert
            Assert.False(valid);
            Assert.Contains(result, vr => vr.MemberNames.Contains("Email"));
        }

        [Fact]
        public void Contact_Validate_EmptyCompanyName_ThrowsException()
        {
            // Arrange
            var contact = new Contact("", "ContactName", "email@example.com", "1234567890");

            var context = new ValidationContext(contact);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(contact, context, result, true);

            // Assert
            Assert.False(valid);
            Assert.Contains(result, vr => vr.MemberNames.Contains("NameCompany"));
        }

        [Fact]
        public void Contact_Validate_EmptyContactName_ThrowsException()
        {
            // Arrange
            var contact = new Contact("CompanyName", "", "email@example.com", "1234567890");

            var context = new ValidationContext(contact);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(contact, context, result, true);

            // Assert
            Assert.False(valid);
            Assert.Contains(result, vr => vr.MemberNames.Contains("NameContact"));
        }

        [Fact]
        public void Contact_Validate_InvalidPhoneNumber_ThrowsException()
        {
            // Arrange
            var contact = new Contact("CompanyName", "ContactName", "email@example.com", "InvalidPhoneNumber");

            var context = new ValidationContext(contact);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(contact, context, result, true);

            // Assert
            Assert.False(valid);
            Assert.Contains(result, vr => vr.MemberNames.Contains("PhoneNumber"));
        }

        [Fact]
        public void Contact_Validate_ValidContact_ReturnsTrue()
        {
            // Arrange
            var contact = new Contact("CompanyName", "ContactName", "email@example.com", "1234567890");

            var context = new ValidationContext(contact);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(contact, context, result, true);

            // Assert
            Assert.True(valid);
        }
    }
}
