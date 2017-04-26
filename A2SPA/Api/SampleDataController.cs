using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using A2SPA.Data.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace A2SPA.Api
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly A2SPAContext _context;

        public SampleDataController(A2SPAContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public TestData Get()
        {
            return _context.TestData.DefaultIfEmpty(null as TestData).LastOrDefault();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
