using AirlineBookingSystem.Models;

namespace AirlineBookingSystem.ViewModels
{
    public class BookNowVM
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
