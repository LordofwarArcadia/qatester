using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CalcTestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/StatusCode")]
    public class StatusCodeController : Controller
    {
        [HttpGet]
        public IActionResult GetStatusCode()
        {
            var enumVals = new List<object>();

            foreach (var item in Enum.GetValues(typeof(HttpStatusCode)))
            {
                if(!enumVals.Any(i => ((dynamic)i).code == (int)item))
                enumVals.Add(new
                {
                    code = (int)item,
                    name = item.ToString()
                });
            }
            return Ok(enumVals);
        }

        [HttpGet("{id}", Name = "GetStatusCode")]
        public IActionResult GetStatusCode(int id)
        {
            foreach (var item in Enum.GetValues(typeof(HttpStatusCode)))
            {
                if(id==(int)item) return StatusCode((int)item<500?200:(int)item, new { Code = (int)item, Name = item.ToString() });
            }
            return NotFound(new { error = $"Status code {id} is not existed." });
        }
    }
}