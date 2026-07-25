using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingSystem.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public double DistanceInKM { get; set; }

        public decimal PricePerKM { get; set; }

        public int AvailableSeats { get; set; }

        public bool IsAvailable { get; set; }


        // Departure Airport

        public int DepartureAirportId { get; set; }
        [ForeignKey(nameof(DepartureAirportId))]
        public Airport DepartureAirport { get; set; }


        // Arrival Airport

        public int ArrivalAirportId { get; set; }
        [ForeignKey(nameof(ArrivalAirportId))]
        public Airport ArrivalAirport { get; set; }

        // Hotel

        public int HotelId { get; set; }
        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; }
    
}
}
