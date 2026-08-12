using AirlineBookingSystem.Models;

namespace AirlineBookingSystem.ViewModels
{
    public class BookingCreateVM
    {
        public IEnumerable<Passenger> Passengers { get; set; }
        public IEnumerable<Flight> Flights { get; set; }

        public IEnumerable<Booking> Booking { get; set; }
    }
}
