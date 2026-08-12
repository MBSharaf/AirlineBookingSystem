using AirlineBookingSystem.Models;

namespace AirlineBookingSystem.ViewModels
{
    public class BookingVM
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }


    }
}
