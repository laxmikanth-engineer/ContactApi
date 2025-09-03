using ContactAPI.Models;
using ContactAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDbController : ControllerBase
    {
        private readonly IContactDbService _contactDbService;

        public ContactDbController(IContactDbService contactDbService)
        {
            _contactDbService = contactDbService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool? isActive = null)
        {
            var contacts = await _contactDbService.GetAllContactsAsync(isActive);
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contact = await _contactDbService.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Contact contact)
        {
            var _contact = await _contactDbService.AddContactAsync(contact);

            if (_contact == null)
            {
                return BadRequest();
            }

            return Ok(new { message = "Contact added sucessfully!", id = _contact!.Id });
        }

        [HttpPut("{id}")]
        //[Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Contact _contact)
        {
            _contact.Id = id;
            var contact = await _contactDbService.UpdateContactAsync(_contact);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(new { message = "Contact updated sucessfully!", id = _contact!.Id });
        }

        [HttpDelete]
        [Route("{id}")]
        public async  Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _contactDbService.DeleteContactAsync(id))
            {
                return NotFound();
            }

            return Ok(new { message = "Contact deleted sucessfully!", id = id });
        }
    }
}
