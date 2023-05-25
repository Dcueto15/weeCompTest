using System.ComponentModel.DataAnnotations;

namespace weeCompanyBackend.Domain.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo \"Nombre de la compañía\" es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo \"Nombre de la compañía\" debe tener como máximo 100 caracteres.")]
        public string NameCompany { get; set; }

        [Required(ErrorMessage = "El campo \"Nombre de contacto\" es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo \"Nombre de contacto\" debe tener como máximo 100 caracteres.")]
        public string NameContact { get; set; }

        [EmailAddress(ErrorMessage = "El campo \"Correo electrónico\" debe tener un formato válido de dirección de correo electrónico.")]
        [MaxLength(100, ErrorMessage = "El campo \"Correo electrónico\" debe tener como máximo 100 caracteres.")]
        public string Email { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "El campo \"Número telefónico\" debe contener solo números.")]
        [MaxLength(20, ErrorMessage = "El campo \"Número telefónico\" debe tener como máximo 20 dígitos.")]
        public string PhoneNumber { get; set; }

        public Contact(string nameCompany, string nameContact, string email, string phoneNumber)
        {
            NameCompany = nameCompany;
            NameContact = nameContact;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
