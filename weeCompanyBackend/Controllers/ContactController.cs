using Microsoft.AspNetCore.Mvc;
using weeCompanyBackend.Domain.IServices;
using weeCompanyBackend.Domain.Models;

namespace weeCompanyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _contactService;
        public ContactController(IContactServices contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var contactList = await _contactService.getAllContacts();
                return Ok(contactList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetContactById(int id)
        {
            try
            {
                var contact = await _contactService.getContactById(id);
                return Ok(contact);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> createContact(Contact contact)
        {
            try
            {
                await _contactService.createContact(contact);
                return Ok(contact);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> updateContact(Contact contact)
        {
            try
            {
                await _contactService.updateContact(contact);
                return Ok(contact);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }

}
