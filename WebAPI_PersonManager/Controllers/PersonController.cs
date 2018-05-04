using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI_PersonManager.Models;

namespace WebAPI_PersonManager.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    //[ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;

            if (_context.PersonItems.Count() == 0)
            {
                _context.PersonItems.Add(new Person { FirstName = "Item",LastName="1",Address="haNoi",Birthday= new System.DateTime(2018,12,30), Sex="Nam" });
                _context.PersonItems.Add(new Person { FirstName = "Item", LastName ="2",Address="haNoi",Birthday= new System.DateTime(2018,12,19), Sex="Nữ" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public List<Person> GetAll()
        {
            return _context.PersonItems.ToList();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetById(long id)
        {
            var item = _context.PersonItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.PersonItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPerson", new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Person item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var per = _context.PersonItems.Find(id);
            if (per == null)
            {
                return NotFound();
            }

            per.FirstName = item.FirstName;
            per.LastName = item.LastName;
            per.Address = item.Address;
            per.Birthday = item.Birthday;
            per.Sex = item.Sex;
            _context.PersonItems.Update(per);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var per = _context.PersonItems.Find(id);
            if (per == null)
            {
                return NotFound();
            }

            _context.PersonItems.Remove(per);
            _context.SaveChanges();
            return NoContent();
        }

       

    }



}