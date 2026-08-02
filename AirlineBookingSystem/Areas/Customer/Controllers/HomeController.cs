using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Repositories;
using AirlineBookingSystem.Utilities;
using AirlineBookingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AirlineBookingSystem.Controllers
{
    [Area(CD.CUSTOMER_AREA)]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        //private readonly Repository<Hotel> _homeRepository;
        public HomeController(ApplicationDbContext context)
        {
            //_context = new ApplicationDbContext();
            _context = context; //new Repository<Hotel>();
        }
        public  IActionResult Index(string HotelName, int page = 1)
        {
            var Hotel = _context.Hotels.AsQueryable();
            //var Hotel = await _context.GetAllAsync();
            if (HotelName != null)
            {
                Hotel = Hotel.Where(h => h.Name.Contains(HotelName));
                ViewBag.HotelName = HotelName;
            }
            
            return View(new HomeSearchVM()
            {
                Hotels = Hotel,
            });
        }

        public IActionResult About()
        {
            var Hotel = _context.Hotels.AsQueryable();
            //var Hotel = await _homeRepository.GetAllAsync();
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
