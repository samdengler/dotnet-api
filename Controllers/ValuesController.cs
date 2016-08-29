using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace vulcan_api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IConfiguration configuration;

        public ValuesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Response.Headers.Add("X-Color", Environment.GetEnvironmentVariable("PARAM1"));
            return new string[]
            {
                "value1",
                "value2",
                configuration.GetValue<string>("PARAM1"),
                Environment.GetEnvironmentVariable("PARAM1")
            };
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
