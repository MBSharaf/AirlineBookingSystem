using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Repositories;
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
        //public readonly ApplicationDbContext _context;
        private readonly IRepository<Airport> _airportRepository;

        public AirportsController(IRepository<Airport> airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<IActionResult> Index(string name , int page = 1)
        {
            //var airports = _context.Airports.AsQueryable();
            var airports = await _airportRepository.GetAllAsync();
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
        public async Task<IActionResult> Create(Airport airport)
        {
            //_context.Airports.Add(airport);
            await _airportRepository.CreateAsync(airport);
            //_context.SaveChanges();
            await _airportRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var airport = _context.Airports.FirstOrDefault(a => a.Id == id);
            var airport = await _airportRepository.GetOneAsync(a => a.Id == id);
            if (airport == null)
            {  return NotFound(); }


            return View(airport);
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Airport airport)
        {
            //_context.Airports.Update(airport);
           _airportRepository.Update(airport);
            //_context.SaveChanges();
            await _airportRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var airport = _context.Airports.FirstOrDefault(a => a.Id == id);
            var airport = await _airportRepository.GetOneAsync(a => a.Id == id);
            if (airport == null)
            { return NotFound(); }

            //_context.Airports.Remove(airport);
            _airportRepository.Delete(airport);
            //_context.SaveChanges();
            await _airportRepository.CommitAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
