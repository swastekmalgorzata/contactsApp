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

            return await _dbContext.Contacts.ToListAsync();
        }

        // GET api/<ContanctsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            if (_dbContext.Contacts == null) {
                return NotFound();

            }
            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return contact;
            
        }

        // POST api/<ContanctsController>
        [HttpPost, Authorize]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        // PUT api/<ContanctsController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<ActionResult> Put(int id,Contact contact)
        {
            if(id != contact.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(contact).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool ContactExists(long id)
        {
            return (_dbContext.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // DELETE api/<ContanctsController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dbContext.Contacts == null)
            {
                return NotFound();

            }

            var contact = await _dbContext.Contacts.FindAsync(id);
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
