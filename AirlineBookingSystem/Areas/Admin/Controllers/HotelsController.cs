using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Repositories;
using AirlineBookingSystem.Services;
using AirlineBookingSystem.Utilities;
using AirlineBookingSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Areas.Admin.Controllers
{
    [Area(CD.ADMIN_AREA)]
    [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE} , {CD.ADMIN_ROLE}")]
    public class HotelsController : Controller
    {
        //public readonly ApplicationDbContext _context;
        private readonly IRepository<Hotel> _hotelRepository;

        public HotelsController(IRepository<Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        private readonly HotelServices _hotelServices = new HotelServices();


        public async Task<IActionResult> Index(string name , int page = 1)
        {
            //var hotels = _context.Hotels.AsQueryable();
            var hotels = await _hotelRepository.GetAllAsync();
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
        public async Task<IActionResult> Create(Hotel hotel, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length>0)
            {
              var fileName = _hotelServices.SaveFile(ImageFile);
                hotel.Image = fileName;
            }
            //_context.Hotels.Add(hotel);
            await _hotelRepository.CreateAsync(hotel);
            //_context.SaveChanges();
            await _hotelRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var hotel = _context.Hotels.FirstOrDefault(a => a.Id == id);
            var hotel = await _hotelRepository.GetOneAsync(a => a.Id == id);
            if (hotel == null)
            { return NotFound(); }


            return View(hotel);
        }
        [HttpPost]
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        public async Task<IActionResult> Edit(Hotel hotel, IFormFile ImageFile)
        {
            //var hotelinDb = _context.Hotels.AsNoTracking().FirstOrDefault(a => a.Id == hotel.Id);
            var hotelinDb = await _hotelRepository.GetOneAsync(a => a.Id == hotel.Id);
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
            //_context.Hotels.Update(hotel);
            await _hotelRepository.CreateAsync(hotel);
            //_context.SaveChanges();
            await _hotelRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var hotel = _context.Hotels.FirstOrDefault(a => a.Id == id);
            var hotel = await _hotelRepository.GetOneAsync(a => a.Id == id);
            if (hotel == null)
            { return NotFound(); }
            _hotelServices.RemoveFile(hotel.Image);
            //_context.Hotels.Remove(hotel);
             await _hotelRepository.CreateAsync(hotel);
             //_context.SaveChanges();
             await _hotelRepository.CommitAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
