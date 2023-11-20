using Microsoft.AspNetCore.Mvc;

namespace Event_Connect_Web.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
