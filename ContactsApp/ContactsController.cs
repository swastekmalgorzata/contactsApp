using Microsoft.AspNetCore.Mvc;
using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsContext _dbContext;
        public ContactsController(ContactsContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<ContanctsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _dbContext.Contacts.ToListAsync());
        }

        // GET api/<ContanctsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST api/<ContanctsController>
        [HttpPost, Authorize]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return Created($"api/Contects/{contact.Id}", contact);
        }

        // PUT api/<ContanctsController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<ActionResult> Put(int id,Contact contact)
        {
            if(id != contact.Id)
            {
                return BadRequest();
            }

            var currentContact = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (currentContact is null)
            {
                return NotFound();
            }
            currentContact.Update(contact);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ContanctsController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
