using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsPaid { get; set; }

        public string PaymentMethod { get; set; }


        // Booking

        public int BookingId { get; set; }
        [ForeignKey(nameof(BookingId))]
        public Booking Booking { get; set; }
    }
}
