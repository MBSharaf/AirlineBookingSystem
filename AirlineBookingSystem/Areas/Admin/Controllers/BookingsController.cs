using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Repositories;
using AirlineBookingSystem.Services;
using AirlineBookingSystem.Utilities;
using AirlineBookingSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AirlineBookingSystem.Areas.Admin.Controllers
{
    [Area(CD.ADMIN_AREA)]
    [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE} , {CD.ADMIN_ROLE}")]
    public class BookingsController : Controller
    {
        //public readonly ApplicationDbContext _context;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<Passenger> _passengerRepository;
        private readonly IRepository<Flight> _flightRepository;

        private readonly BookingServices _bookingServices = new BookingServices();

        public BookingsController(IRepository<Booking> bookingRepository, IRepository<Passenger> passengerRepository, IRepository<Flight> flightRepository, BookingServices bookingServices)
        {
            _bookingRepository = bookingRepository;
            _passengerRepository = passengerRepository;
            _flightRepository = flightRepository;
            _bookingServices = bookingServices;
        }

        public async Task<IActionResult> Index(string name, int page = 1)
        {
            //var bookings = _context.Bookings.Include(b => b.Passenger).Include(b => b.Flight).AsQueryable();
            var bookings = await _bookingRepository.GetAllAsync(includes: new Expression<Func<Booking, object>>[]
            {
                b => b.Passenger,
                b => b.Flight
            });

            if (name != null)
            {
                bookings = bookings.Where(a => a.Flight.FlightNumber.Contains(name));
                ViewBag.name = name;
            }
            int totalpages = (int)Math.Ceiling(bookings.Count() / 6.0);

            bookings = bookings.Skip((page - 1) * 6).Take(6);

            return View(new BookingVM()
            {
                Bookings = bookings.AsEnumerable(),
                TotalPages = totalpages,
                CurrentPage = page
            });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var passengers = _context.Passengers.AsQueryable();
            var passengers = await _passengerRepository.GetAllAsync();
            //var flights = _context.Flights.AsQueryable();
            var flights = await _flightRepository.GetAllAsync();
            //var booking = _context.Bookings.AsQueryable();
            var booking = await _bookingRepository.GetAllAsync();
            return View(new BookingCreateVM()
            {
                Passengers = passengers,
                Flights = flights,
                Booking = booking
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            //if (ImageFile != null && ImageFile.Length>0)
            //{
            //  var fileName = _bookingServices.SaveFile(ImageFile);
            //    booking.Image = fileName;
            //}
            //_context.Bookings.Add(booking);
            await _bookingRepository.CreateAsync(booking);
            //_context.SaveChanges();
            await _bookingRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var booking = _context.Bookings.FirstOrDefault(a => a.Id == id);
            var booking = await _bookingRepository.GetOneAsync(a => a.Id == id);
            if (booking == null)
            { return NotFound(); }


            return View(booking);
        }
        [HttpPost]
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        public async Task<IActionResult> Edit(Booking booking)
        {
            //var bookinginDb = _context.Bookings.AsNoTracking().FirstOrDefault(a => a.Id == booking.Id);
            var bookinginDb = await _bookingRepository.GetOneAsync(a => a.Id == booking.Id);
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
            //_context.Bookings.Update(booking);
            _bookingRepository.Update(booking);
            //_context.SaveChanges();
            await _bookingRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var booking = _context.Bookings.FirstOrDefault(a => a.Id == id);
            var booking = await _bookingRepository.GetOneAsync(a => a.Id == id);
            if (booking == null)
            { return NotFound(); }
            //_bookingServices.RemoveFile(booking.Image);
            //_context.Bookings.Remove(booking);
             _bookingRepository.Delete(booking);
             //_context.SaveChanges();
             await _bookingRepository.CommitAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
