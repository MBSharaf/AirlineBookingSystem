using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Utilities;
using AirlineBookingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AirlineBookingSystem.Areas.Customer.Controllers
{
    [Area(CD.CUSTOMER_AREA)]
    public class BookNowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookNowController()
        {
            _context = new ApplicationDbContext();
        }
        public IActionResult Index(string BookNowName, int page = 1)
        {
            var Hotel = _context.Hotels.AsQueryable();
            if (BookNowName != null)
            {
                Hotel = _context.Hotels.Where(h => h.Name.Contains(BookNowName));
                ViewBag.BookNowName = BookNowName;
            }
            var totalPages = (int)Math.Ceiling(Hotel.Count() / 8.0);
            Hotel = Hotel.Skip((page - 1) * 8).Take(8);

            return View(new BookNowVM()
            {
                Hotels = Hotel,
                TotalPages = totalPages,
                CurrentPage = page
            });
           
        }


        public IActionResult HotelDetails(int id)
        {
            var Hotel = _context.Hotels.FirstOrDefault(h => h.Id == id);
            if (Hotel == null)
            {
                return NotFound();
            }
            string city = Hotel.City;
            var Airport = _context.Airports.FirstOrDefault(a => a.City == Hotel.City);
            var flights = _context.Flights.Where(f => f.HotelId == Hotel.Id).ToList();

            return View(new HotelDetailsVM()
            {
                Hotel = Hotel,
                Airport = Airport,
                Flights = flights
            });
        }
    }
}
