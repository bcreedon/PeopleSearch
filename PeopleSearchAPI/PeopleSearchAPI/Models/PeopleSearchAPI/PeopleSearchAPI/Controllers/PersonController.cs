using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleSearchAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            return await _context.Person.ToListAsync();
        }


        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person Person)
        {
            if (id != Person.RecID)
            {
                return BadRequest();
            }
            _context.Entry(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var Person = await _context.Person.FindAsync(id);

            if (Person == null)
            {
                return NotFound();
            }

            return Person;
        }

        // POST: api/Person
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person Person)
        {
            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = Person.RecID }, Person);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var Person = await _context.Person.FindAsync(id);
            if (Person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(Person);
            await _context.SaveChangesAsync();

            return Person;
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.RecID == id);
        }
    }
}
