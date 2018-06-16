using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeServices.Models;
using EmployeeServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        IDataAccess<Employee, int> _bookRepo;
        public EmployeeController(IDataAccess<Employee, int> b)
        {
            _bookRepo = b;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var books = _bookRepo.GetBooks();
            return books;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookRepo.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Employee b)
        {
            int res = _bookRepo.AddBook(b);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee b)
        {
            if (id == b.Id)
            {
                int res = _bookRepo.UpdateBook(id, b);
                if (res != 0)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int res = _bookRepo.DeleteBook(id);
            if (res != 0)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}