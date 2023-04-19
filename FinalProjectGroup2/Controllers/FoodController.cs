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
            if (food == null)
            {
                return NotFound();
            }
            return(Ok(food));
        }

        [HttpDelete("id")]

        public IActionResult Delete(int id) {
            var food = _context.RemoveFoodById(id);

            if (team == null)
            {
                return NotFound(id);
            }
            if (string.IsNullOrEmpty(food.Name))
            {
                return StatusCode(500, "An error occured while processing your request");
            }
            return Ok();
         }
    }
}
