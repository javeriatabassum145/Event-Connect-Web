using Event_Connect_Web.Data;
using Event_Connect_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Connect_Web.Controllers
{
    public class EventController : Controller
    {
        private readonly EventContext _context;
        public EventController(EventContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Event> objEventList = _context.Event.Include(e => e.Organizer);
            return View(objEventList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event eventobj)
        {
            if (ModelState.IsValid)
            {
                var cdate = DateTime.Now;
                eventobj.Date = cdate;

                _context.Event.Add(eventobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(eventobj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var eventFromDb = _context.Event.Include(e => e.Organizer).FirstOrDefault(e => e.EventID == id);

            if (eventFromDb == null)
            {
                return NotFound();
            }

            return View(eventFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Event eventobj)
        {
            if (ModelState.IsValid)
            {
                _context.Update(eventobj);

                // Update related User (Organizer) entity
                _context.Entry(eventobj.Organizer).State = EntityState.Modified;

                _context.SaveChanges();

                TempData["ResultOk"] = "Data Updated Successfully!";
                return RedirectToAction("Index");
            }

            return View(eventobj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var eventFromDb = _context.Event.Include(e => e.Organizer).FirstOrDefault(e => e.EventID == id);

            if (eventFromDb == null)
            {
                return NotFound();
            }

            return View(eventFromDb);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var eventFromDb = _context.Event.Include(e => e.Organizer).FirstOrDefault(e => e.EventID == id);

            if (eventFromDb == null)
            {
                return NotFound();
            }

            _context.Event.Remove(eventFromDb);

            // Optionally, you may want to delete the associated User (Organizer) entity
            _context.User.Remove(eventFromDb.Organizer);

            _context.SaveChanges();

            TempData["ResultOk"] = "Data Deleted Successfully!";
            return RedirectToAction("Index");
        }

    }
}
