using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public int NumberOfSeats { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsConfirmed { get; set; }


        // Passenger

        public int PassengerId { get; set; }
        [ForeignKey(nameof(PassengerId))]
        public Passenger Passenger { get; set; }


        // Flight

        public int FlightId { get; set; }
        [ForeignKey(nameof(FlightId))]
        public Flight Flight { get; set; }
    }
}
