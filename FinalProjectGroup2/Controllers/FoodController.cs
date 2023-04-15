using Microsoft.AspNetCore.Mvc;

namespace FinalProjectGroup2.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
