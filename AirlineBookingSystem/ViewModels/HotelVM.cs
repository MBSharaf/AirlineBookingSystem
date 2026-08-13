using AirlineBookingSystem.Models;

namespace AirlineBookingSystem.ViewModels
{
    public class HotelVM
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }


    }
}
