using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using A2SPA.Data.Models;
using A2SPA.Data.Repo;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace A2SPA.Api
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly ITestUserRepository _repo;
        private readonly IMapper _mapper;

        public SampleDataController(IMapper mapper, ITestUserRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public A2SPA.ViewModels.TestData Get()
        {
            var data = _repo.GetTestDatas(0, 0).LastOrDefault();

            return _mapper.Map<A2SPA.ViewModels.TestData>(data);
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
