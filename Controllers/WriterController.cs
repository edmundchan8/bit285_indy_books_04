using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IndyBooks.Models;
using IndyBooks.ViewModels;
using IndyBooks.Migrations;

namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private IndyBooksDataContext _dbc;
        public WriterController (IndyBooksDataContext indyBooksdb) 
        {
            _dbc = indyBooksdb;
        }


        // GET: api/Writer
        [HttpGet]
        public IActionResult Get()
        {
            var writers = _dbc.Writers;
            return Ok(writers.Select(w => new { id = w.Id, name = w.Name, books = ""}));
        }

        // GET: api/Writer/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var writers = _dbc.Writers;
            if (writers.Any(w => w.Id == id))
                return Ok(writers.Select(w => new { id = w.Id, name = w.Name }).Where(w => w.id == id));
            return NotFound(id);
        }

        // POST: api/Writer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Writer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
