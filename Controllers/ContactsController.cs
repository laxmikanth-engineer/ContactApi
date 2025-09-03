using ContactAPI.Models;
using ContactAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            return Ok(_contactService.GetAllContacts(isActive));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _contactService.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            var _contact = _contactService.AddContact(contact);

            if (_contact == null)
            {
                return BadRequest();
            }

            return Ok(new { message = "Contact added sucessfully!", id = _contact!.Id });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Contact _contact) 
        {
            _contact.Id = id;
            var contact = _contactService.UpdateContact(_contact);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(new { message = "Contact updated sucessfully!", id = _contact!.Id });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if(!_contactService.DeleteContact(id))
            {
                return NotFound();
            }

            return Ok(new { message = "Contact deleted sucessfully!", id = id });
        }
    }
}
