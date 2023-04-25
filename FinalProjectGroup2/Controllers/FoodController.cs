using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProjectGroup2.Interfaces;
using System.Linq;

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
            return Ok(_context.GetAllFoods());
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var food = _context.GetFoodById(id);
            //If null or zero is provided for the id, return the first five results from the table.
            if (food == null || id == 0)
            {
                //return NotFound();
                Ok(_context.GetAllFoods().Take(5));
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

        [HttpPost]

        public IActionResult Post(Food food)
        {
            var result = _context.Add(food);

            if (result == null)
            {
                return StatusCode(500, "Food already exists");
            }
            if (result == 0)
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
        }
    }
}
