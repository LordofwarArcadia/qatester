using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalcTestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Multiply")]
    public class MultiplyController : Controller
    {
        // GET: api/Multiply
        [HttpGet]
        public IActionResult Get([FromQuery] string firstValue, string secondValue)
        {
            return CalculateMultiply(firstValue, secondValue);
        }

        // GET: api/Multiply/5
        [HttpGet("{id}", Name = "GetMultiply")]
        public IActionResult Get(int id)
        {
            return StatusCode(500, new { error = "Hi, you found a bug! Id is not applicable for the calculator functions! Congrats! :)" });
        }

        // POST: api/Multiply
        [HttpPost]
        public IActionResult Post([FromBody]string firstValue, string secondValue)
        {
            return CalculateMultiply(firstValue, secondValue);
        }

        // PUT: api/Multiply/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return StatusCode(500, new { error = "Hi, you found a bug! Id is not applicable for the calculator functions! Congrats! :)" });
        }

        // DELETE: api/Multiply/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(500, new { error = "Hi, you found a bug! Id is not applicable for the calculator functions! Congrats! :)" });
        }

        private IActionResult CalculateMultiply(string firstValue, string secondValue)
        {
            if (string.IsNullOrEmpty(firstValue) || string.IsNullOrEmpty(secondValue))
            {
                return StatusCode(400, new { message = "Hey! You found a bug with empty parameters for 'Multiply' operation! Gratz!" });
            }
            if (firstValue.ToCharArray().Any(i => i <= 45 || i >= 57 || i == 47)
                ||
                secondValue.ToCharArray().Any(i => i < 45 || i >= 57 || i == 47))
            {
                return StatusCode(400, new { message = "Hey! You found a bug with not valid characters for 'Multiply' operation! Gratz!" });
            }
            if (firstValue.Equals("-0") || secondValue.Equals("-0")) return StatusCode(400, new { message = "Hmmm. Heh. -0?! Nice test case! For 'Multiply' operation ofc" });

            var firstNumber = Convert.ToInt32(firstValue);
            var secondNumber = Convert.ToInt32(secondValue);
            if (firstNumber == 0 || secondNumber == 0) return StatusCode(200, new { result = $"The result of multiplying of {firstValue} and {secondValue} is {firstNumber * secondNumber}. And Yeah! You checked the zero cases for 'Multiply' operation! Gratz!" });

            return StatusCode(200, new { result = $"The result of multiplying of {firstValue} and {secondValue} is {firstNumber * secondNumber}" });
        }
    }
}
