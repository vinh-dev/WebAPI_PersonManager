using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI_PersonManager.Models;


namespace WebAPI_CustomerManager.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;

            if (_context.CustomerItems.Count() == 0)
            {
                _context.CustomerItems.Add(new Customer { Name = "Item 1", Address = " Hà Nội", Phone = "096311305" });
                _context.CustomerItems.Add(new Customer { Name = "Item 2", Address = "namDinh", Phone = "093473687" });
                _context.CustomerItems.Add(new Customer { Name = "Item 3", Address = "haNam", Phone = "112" });
                _context.CustomerItems.Add(new Customer { Name = "Item 4", Address = "haNoi", Phone = "0937" });
                _context.CustomerItems.Add(new Customer { Name = "Item 5", Address = "quangninh", Phone = "44645" });
                _context.CustomerItems.Add(new Customer { Name = "Item 6", Address = "haiaphong", Phone = "03687" });
                _context.CustomerItems.Add(new Customer { Name = "Item 7", Address = "lungcu", Phone = "073687" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public List<Customer> GetAll()
        {
            var result = _context.CustomerItems.ToList();
            return result;
        }

        [HttpGet("{id}", Name = "GetCustomer")]

        public IActionResult GetById(long id)
        {
            var item = _context.CustomerItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Customer item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var per = _context.CustomerItems.Find(id);
            if (per == null)
            {
                return NotFound();
                
            }
            else
            {
                per.Name = item.Name;
                per.Address = item.Address;
                per.Phone = item.Phone;
                _context.CustomerItems.Update(per);
                _context.SaveChanges();
                //return NoContent();
                return Ok("UpdateDone");
            }

        }
        [HttpPost]
        public IActionResult Create([FromBody] Customer item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _context.CustomerItems.Add(item);
            _context.SaveChanges();

            //return CreatedAtRoute("GetCustomer", new { id = item.ID }, item);
            return Ok("Create Done");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var per = _context.CustomerItems.Find(id);
            if (per == null)
            {
                return NotFound();
            }

            _context.CustomerItems.Remove(per);
            _context.SaveChanges();
            //return NoContent();
            return Ok("deletedone");
        }
    }
}