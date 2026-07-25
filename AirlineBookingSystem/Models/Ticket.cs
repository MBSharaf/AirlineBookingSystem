using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string TicketNumber { get; set; }

        public decimal TicketPrice { get; set; }

        public DateTime IssueDate { get; set; }


        // Booking
        public int BookingId { get; set; }
        [ForeignKey(nameof(BookingId))]
        public Booking Booking { get; set; }
    }
}
