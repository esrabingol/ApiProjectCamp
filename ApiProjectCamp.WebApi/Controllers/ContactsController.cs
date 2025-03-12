using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ContactDtos;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _apiContext;

        public ContactsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            List<Contact> value = _apiContext.Contacts.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContact)
        {
            Contact contact = new Contact();

            contact.Email = createContact.Email;
            contact.Address = createContact.Address;
            contact.Phone = createContact.Phone;
            contact.MapLocation = createContact.MapLocation;
            contact.OpenHours = createContact.OpenHours;

            _apiContext.Add(contact);
            _apiContext.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            Contact value = _apiContext.Contacts.Find(id);
            _apiContext.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            Contact value = _apiContext.Contacts.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto contactDto)
        {
            Contact contact = new Contact();
            contact.Email = contactDto.Email;
            contact.Address = contactDto.Address;
            contact.Phone = contactDto.Phone;
            contact.ContactId = contactDto.ContactId;
            contact.MapLocation = contactDto.MapLocation;
            contact.OpenHours = contactDto.OpenHours;
            _apiContext.Update(contact);
            _apiContext.SaveChanges();
            return Ok("Değişiklikler başarıyla güncellendi.");

        }
    }
}
