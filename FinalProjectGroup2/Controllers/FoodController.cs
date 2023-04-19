using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProjectGroup2.Interfaces;

namespace FinalProjectGroup2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;

        private readonly IFoodContextDAO _context;

        public FoodController(ILogger<FoodController> logger, IFoodContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_context.GetAllFood());
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var food = _context.GetFoodById(id);
            //If null or zero is provided for the id, return the first five results from the table.
            if (food == null || id == 0)
            {
                //return NotFound();
                Ok(_context.GetAllFood().Take(5);
            }
            return(Ok(food));
        }

        [HttpDelete("id")]

        public IActionResult Delete(int id) {
            var result = _context.RemoveFoodById(id);

            if (result == null)
            {
                return NotFound(id);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
         }

        [HttpPut]

        public IActionResult Put(Food food)
        {
            var result = _context.UpdateFood(food);

            if (result == null)
            {
                return NotFound(food.Id);
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }
    }
}
