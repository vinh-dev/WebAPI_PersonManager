using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_PersonManager.Models;

namespace WebAPI_PersonManager.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    //[ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ManagerContext _context;

        public PersonController(ManagerContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<List<Person>> GetAll()
        {
            return await _context.PersonItems.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public async Task<IActionResult> GetById(long id)
        {
            var item = await _context.PersonItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _context.PersonItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetPerson", new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Person item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var perToUpdate = _context.PersonItems.Find(id);

            if (perToUpdate == null)
            {
                return NotFound();
            }
            perToUpdate.FirstName = item.FirstName;
            perToUpdate.LastName = item.LastName;
            perToUpdate.Address = item.Address;
            perToUpdate.Birthday = item.Birthday;
            perToUpdate.Sex = item.Sex;

            _context.PersonItems.Update(perToUpdate);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var per = await _context.PersonItems.FirstAsync(s => s.Id == id);
            if (per == null)
            {
                return NotFound();
            }

            _context.PersonItems.Remove(per);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }



}