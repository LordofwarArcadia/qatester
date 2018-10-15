using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CalcTestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Minus")]
    public class MinusController : Controller
    {
        // GET: api/Minus
        [HttpGet]
        public IActionResult Get([FromQuery] string firstValue, string secondValue)
        {
            return CalculateMinus(firstValue, secondValue);
        }

        // GET: api/Minus/5
        [HttpGet("{id}", Name = "GetMinus")]
        public IActionResult Get(int id)
        {
            return StatusCode(500, new { error = "Hi, you found a bug! Id is not applicable for the calculator functions! Congrats! :)" });
        }

        // POST: api/Minus
        [HttpPost]
        public IActionResult Post([FromBody]string firstValue, string secondValue)
        {
            return CalculateMinus(firstValue, secondValue);
        }

        // PUT: api/Minus/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return StatusCode(500, new { error = "Hi, you found a bug! Id is not applicable for the calculator functions! Congrats! :)" });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(500, new { error = "Hi, you found a bug! Id is not applicable for the calculator functions! Congrats! :)" });
        }

        private IActionResult CalculateMinus(string firstValue, string secondValue)
        {
            if (string.IsNullOrEmpty(firstValue) || string.IsNullOrEmpty(secondValue))
            {
                return StatusCode(400, new { message = "Hey! You found a bug with empty parameters for 'Minus' operation! Gratz!" });
            }
            if (firstValue.ToCharArray().Any(i => i <= 45 || i >= 57 || i == 47)
                ||
                secondValue.ToCharArray().Any(i => i < 45 || i >= 57 || i == 47))
            {
                return StatusCode(400, new { message = "Hey! You found a bug with not valid characters for 'Minus' operation! Gratz!" });
            }
            if (firstValue.Equals("-0") || secondValue.Equals("-0")) return StatusCode(400, new { message = "Hmmm. Heh. -0?! Nice test case! For 'Minus' operation ofc" });

            var firstNumber = Convert.ToInt32(firstValue);
            var secondNumber = Convert.ToInt32(secondValue);
            if (firstNumber == 0 || secondNumber == 0) return StatusCode(200, new { result = $"The result of subtraction of {firstValue} and {secondValue} is {firstNumber - secondNumber}. And Yeah! You checked the zero cases for 'Minus' operation! Gratz!" });

            return StatusCode(200, new { result = $"The result of subtraction of {firstValue} and {secondValue} is {firstNumber - secondNumber}" });
        }
    }
}
