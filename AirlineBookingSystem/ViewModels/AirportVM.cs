using AirlineBookingSystem.Models;

namespace AirlineBookingSystem.ViewModels
{
    public class AirportVM
    {
        public IEnumerable<Airport> Airports { get; set; }  
        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }


    }
}
