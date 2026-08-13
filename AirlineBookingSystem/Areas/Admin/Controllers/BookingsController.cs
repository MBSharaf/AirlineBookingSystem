using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
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
    public class BookingsController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly BookingServices _bookingServices = new BookingServices();

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
          
        }

        public IActionResult Index(string name , int page = 1)
        {
            var bookings = _context.Bookings.Include(b => b.Passenger).Include(b => b.Flight).AsQueryable();
           if (name != null)
            {
                bookings = bookings.Where(a => a.Flight.FlightNumber.Contains(name));
                ViewBag.name = name;
            }
           int totalpages = (int)Math.Ceiling(bookings.Count()/6.0);
           
           bookings = bookings.Skip((page - 1) * 6).Take(6);

            return View(new BookingVM()
            { 
                Bookings = bookings.AsEnumerable(),
                TotalPages = totalpages,
                CurrentPage = page
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            var passengers = _context.Passengers.AsQueryable();
            var flights = _context.Flights.AsQueryable();
            var booking = _context.Bookings.AsQueryable();
            return View(new BookingCreateVM()
            {
                Passengers = passengers,
                Flights = flights,
                Booking = booking
            });
        }
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            //if (ImageFile != null && ImageFile.Length>0)
            //{
            //  var fileName = _bookingServices.SaveFile(ImageFile);
            //    booking.Image = fileName;
            //}
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(a => a.Id == id);
            if (booking == null)
            { return NotFound(); }


            return View(booking);
        }
        [HttpPost]
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        public IActionResult Edit(Booking booking)
        {
            var bookinginDb = _context.Bookings.AsNoTracking().FirstOrDefault(a => a.Id == booking.Id);
            if (bookinginDb == null)
            { return NotFound(); }
            //if (ImageFile != null && ImageFile.Length > 0)
            //{
            //    var fileName = _bookingServices.SaveFile(ImageFile);
            //    booking.Image = fileName;
            //    _bookingServices.RemoveFile(bookinginDb.Image);

            //}
            //else
            //{
            //    booking.Image = bookinginDb.Image;
            
            //}
            _context.Bookings.Update(booking);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(a => a.Id == id);
            if (booking == null)
            { return NotFound(); }
            //_bookingServices.RemoveFile(booking.Image);
            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
