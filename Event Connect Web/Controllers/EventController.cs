using Microsoft.AspNetCore.Mvc;

namespace Event_Connect_Web.Controllers
{
    public class EventController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
