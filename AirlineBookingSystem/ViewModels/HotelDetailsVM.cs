using AirlineBookingSystem.Models;

namespace AirlineBookingSystem.ViewModels
{
    public class HotelDetailsVM
    {
        public Hotel Hotel { get; set; }

        public Airport Airport { get; set; }

        public List<Flight> Flights { get; set; }
    }
}
