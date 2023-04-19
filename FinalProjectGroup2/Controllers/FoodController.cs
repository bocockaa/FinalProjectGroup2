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

        [HttpGet]
        public IActionResult Get(int id)
        {
            var food = _context.GetFood(id);
            if (food == null)
            {
                return NotFound();
            } else
            {

            }
            return(Ok(food));
        }
    }
}
