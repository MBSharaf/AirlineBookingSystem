using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Services;
using AirlineBookingSystem.Utilities;
using AirlineBookingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Areas.Admin.Controllers
{
    [Area(CD.ADMIN_AREA)]
    public class HotelsController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly HotelServices _hotelServices = new HotelServices();

        public HotelsController(ApplicationDbContext context)
        {
            _context = context;
          
        }

        public IActionResult Index(string name , int page = 1)
        {
            var hotels = _context.Hotels.AsQueryable();
           if (name != null)
            {
                hotels = hotels.Where(a => a.Name.Contains(name));
                ViewBag.name = name;
            }
           int totalpages = (int)Math.Ceiling(hotels.Count()/6.0);
           
           hotels = hotels.Skip((page - 1) * 6).Take(6);

            return View(new HotelVM()
            { 
                Hotels = hotels.AsEnumerable(),
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
        public IActionResult Create(Hotel hotel, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length>0)
            {
              var fileName = _hotelServices.SaveFile(ImageFile);
                hotel.Image = fileName;
            }
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(a => a.Id == id);
            if (hotel == null)
            { return NotFound(); }


            return View(hotel);
        }
        [HttpPost]
        public IActionResult Edit(Hotel hotel, IFormFile ImageFile)
        {
            var hotelinDb = _context.Hotels.AsNoTracking().FirstOrDefault(a => a.Id == hotel.Id);
            if (hotelinDb == null)
            { return NotFound(); }
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = _hotelServices.SaveFile(ImageFile);
                hotel.Image = fileName;
                _hotelServices.RemoveFile(hotelinDb.Image);

            }
            else
            {
                hotel.Image = hotelinDb.Image;
            
            }
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(a => a.Id == id);
            if (hotel == null)
            { return NotFound(); }
            _hotelServices.RemoveFile(hotel.Image);
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
