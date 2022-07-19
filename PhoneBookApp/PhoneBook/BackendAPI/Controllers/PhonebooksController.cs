using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook;
using PhoneBook.Data;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonebooksController : ControllerBase
    {
        private readonly PhonebookDbContext _context;

        public PhonebooksController(PhonebookDbContext context)
        {
            _context = context;
        }

        // GET: api/phonebooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phonebook>>> GetPhonebooks()
        {
          if (_context.Phonebooks == null)
          {
              return NotFound();
          }
            return await _context.Phonebooks.ToListAsync();
        }

        // GET: api/phonebooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phonebook>> GetPhonebook(int id)
        {
          if (_context.Phonebooks == null)
          {
              return NotFound();
          }
            var phonebook = await _context.Phonebooks.FindAsync(id);

            if (phonebook == null)
            {
                return NotFound();
            }

            return phonebook;
        }

        // PUT: api/phonebooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhonebook(int id, Phonebook phonebook)
        {
            if (id != phonebook.Id)
            {
                return BadRequest();
            }

            _context.Entry(phonebook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhonebookExists(id))
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

        // POST: api/phonebooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Phonebook>> PostPhonebook(Phonebook phonebook)
        {
          if (_context.Phonebooks == null)
          {
              return Problem("Entity set 'PhonebookDbContext.Phonebooks'  is null.");
          }
            _context.Phonebooks.Add(phonebook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhonebook", new { id = phonebook.Id }, phonebook);
        }

        // DELETE: api/phonebooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhonebook(int id)
        {
            if (_context.Phonebooks == null)
            {
                return NotFound();
            }
            var phonebook = await _context.Phonebooks.FindAsync(id);
            if (phonebook == null)
            {
                return NotFound();
            }

            _context.Phonebooks.Remove(phonebook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhonebookExists(int id)
        {
            return (_context.Phonebooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
