using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using A2SPA.Data.Models;
using A2SPA.Data.Repo;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace A2SPA.Api
{
    [Authorize]
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

        // GET api/sampleData/{1}
        /// <summary>
        /// Returns a single TestData record with matching Id
        /// </summary>
        /// <remarks>This method will return an IActionResult containing the TestData record and StatusCode 200 if successful. 
        /// If there is a an error, you will get a status message and StatusCode which will indicate what was the error.</remarks>
        /// <param name="id">the ID of the record to retrieve</param>
        /// <returns>an IActionResult</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var testData = await _repo.GetTestDataAsync(id);

            if (testData == null) return Json(NoContent());

            return Json(Ok(testData));
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
