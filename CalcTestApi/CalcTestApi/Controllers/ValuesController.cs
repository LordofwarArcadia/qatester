using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CalcTestApi.Controllers
{
    [Route("api/endpoints")]
    public class ValuesController : Controller
    {
        // GET api/endpoints
        [HttpGet]
        public IActionResult Get()
        {
            Dictionary<string, string> endpoints = new Dictionary<string, string>()
            {
                {"Plus","/api/plus?firstValue=123&secondValue=123" },
                {"Minus","/api/minus?firstValue=123&secondValue=123" },
                {"Multiply","/api/multiply?firstValue=123&secondValue=123" },
                {"Divide","/api/divide?firstValue=123&secondValue=123" }
            };
            return Ok(endpoints);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return NotFound(new {error = "Hell Yeah! You can work with /api/endpoints only to get the list of endpoints and nothing else!" });
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return NotFound(new {error = "Hell Yeah! You can work with /api/endpoints only to get the list of endpoints and nothing else!" });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return NotFound(new {error = "Hell Yeah! You can work with /api/endpoints only to get the list of endpoints and nothing else!" });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NotFound(new {error = "Hell Yeah! You can work with /api/endpoints only to get the list of endpoints and nothing else!" });
        }
    }
}
