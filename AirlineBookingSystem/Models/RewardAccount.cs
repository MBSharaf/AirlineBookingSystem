using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingSystem.Models
{
    public class RewardAccount
    {
        public int Id { get; set; }
        public int TotalPoints { get; set; }

        // Passenger
        public int PassengerId { get; set; }
        [ForeignKey(nameof(PassengerId))]
        public Passenger Passenger { get; set; }
    }

}
