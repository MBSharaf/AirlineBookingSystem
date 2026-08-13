using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Utilities;
using AirlineBookingSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Areas.Admin.Controllers
{
    [Area(CD.ADMIN_AREA)]
    [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE} , {CD.ADMIN_ROLE}")]
    public class AirportsController : Controller
    {
        public readonly ApplicationDbContext _context;

        public AirportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string name , int page = 1)
        {
            var airports = _context.Airports.AsQueryable();
           if (name != null)
            {
                airports = airports.Where(a => a.Name.Contains(name));
                ViewBag.name = name;
            }
           int totalpages = (int)Math.Ceiling(airports.Count()/6.0);
           
           airports = airports.Skip((page - 1) * 6).Take(6);

            return View(new AirportVM()
            { 
                Airports = airports.AsEnumerable(),
                TotalPages = totalpages,
                CurrentPage = page
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Airport airport)
        {
            _context.Airports.Add(airport);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var airport = _context.Airports.FirstOrDefault(a => a.Id == id);
            if (airport == null)
            {  return NotFound(); }


            return View(airport);
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        [HttpPost]
        public IActionResult Edit(Airport airport)
        {
            _context.Airports.Update(airport);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        public IActionResult Delete(int id)
        {
            var airport = _context.Airports.FirstOrDefault(a => a.Id == id);
            if (airport == null)
            { return NotFound(); }

            _context.Airports.Remove(airport);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
