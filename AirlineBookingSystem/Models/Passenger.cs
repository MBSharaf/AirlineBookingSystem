namespace AirlineBookingSystem.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? PassportNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Nationality { get; set; }

        public string? Gender { get; set; }
    }
}
