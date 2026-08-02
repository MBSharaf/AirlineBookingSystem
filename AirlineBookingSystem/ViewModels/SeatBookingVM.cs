using AirlineBookingSystem.Models;

namespace AirlineBookingSystem.ViewModels
{
    public class SeatBookingVM
    {
        public Hotel Hotel { get; set; }
        public Airport Airport { get; set; }

        public Flight Flight { get; set; }

        public Ticket Ticket { get; set; }

        public Passenger Passenger { get; set; }

        public Airport DepartureAirport { get; set; }

        public Airport ArrivalAirport { get; set; }

    }
}
