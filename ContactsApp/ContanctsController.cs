using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContanctsController : ControllerBase
    {
        // GET: api/<ContanctsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContanctsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContanctsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContanctsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContanctsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
