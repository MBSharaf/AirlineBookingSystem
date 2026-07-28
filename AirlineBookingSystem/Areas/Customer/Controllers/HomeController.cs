using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirlineBookingSystem.Controllers
{
    [Area(CD.CUSTOMER_AREA)]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public IActionResult Index()
        {
            var Hotel = _context.Hotels.AsQueryable();
            Hotel = Hotel.Skip(0).Take(3);
            return View(Hotel);
        }

        public IActionResult About()
        {
            var Hotel = _context.Hotels.AsQueryable();
            Hotel = Hotel.Skip(0).Take(3);
            return View(Hotel);
        }


        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
