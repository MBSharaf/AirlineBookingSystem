using AirlineBookingSystem.Models;

namespace AirlineBookingSystem.ViewModels
{
    public class HomeSearchVM
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
