using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using AirlineBookingSystem.Repositories;
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
        //private readonly ApplicationDbContext _context;
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly IRepository<Flight> _flightRepository;
        private readonly IRepository<Airport> _airportRepository;
        private readonly IRepository<Ticket> _ticketRepository;

        public BookNowController(IRepository<Hotel> hotelRepository, IRepository<Flight> flightRepository, IRepository<Airport> airportRepository, IRepository<Ticket> ticketRepository)
        {
            _hotelRepository = hotelRepository;
            _flightRepository = flightRepository;
            _airportRepository = airportRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<IActionResult> Index(string BookNowName, int page = 1)
        {
            //var Hotel = _context.Hotels.AsQueryable();
            var Hotel = await _hotelRepository.GetAllAsync();
            if (BookNowName != null)
            {
                Hotel = Hotel.Where(h => h.Name.Contains(BookNowName));
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


        public async Task<IActionResult> HotelDetails(int id)
        {
            //var Hotel = _context.Hotels.FirstOrDefault(h => h.Id == id);
            var Hotel = await _hotelRepository.GetOneAsync(h => h.Id == id);
            if (Hotel != null)
            {
                string city = Hotel.City;
            }
            
             var airport = await _airportRepository.GetOneAsync(a => a.City == Hotel.City);
             var flights = await _flightRepository.GetAllAsync(f => f.HotelId == Hotel.Id);


            return View(new HotelDetailsVM()
            {
                Hotel = Hotel,
                Airport = airport,
                Flights = flights.ToList()
            });
        }


        public async Task<IActionResult> ChoseSeat(int id)
        {
            //var hotel = _context.Hotels.FirstOrDefault(t => t.Id == id);
            var hotel = await _hotelRepository.GetOneAsync(t => t.Id == id);
            //var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            var ticket = await _ticketRepository.GetOneAsync(t => t.Id == id);
            //var flights = _context.Flights.FirstOrDefault(f => f.Id == id);
            var flights = await _flightRepository.GetOneAsync(f => f.Id == id);
            //var airport = _context.Airports.FirstOrDefault(f => f.Id == id);
            var airports = await _airportRepository.GetOneAsync(f => f.Id == id);

            return View(new SeatBookingVM()
            {
                Ticket = ticket,
                Flight = flights,
                Airport = airports,
                Hotel = hotel
            });
        }

    }
}
