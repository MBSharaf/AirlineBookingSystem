using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addDataInBookingsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('12/2/2025', 4, 7721.37, 1, 1, 1);insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('4/18/2027', 1, 4567.34, 1, 2, 2);insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('8/27/2026', 7, 3433.63, 1, 3, 3);insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('4/27/2026', 8, 4768.56, 1, 4, 4);insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('3/22/2027', 2, 3298.98, 1, 5, 5);insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('4/25/2027', 4, 4391.5, 1, 6, 6);insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('6/29/2027', 3, 6154.2, 1, 7, 7);insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('10/4/2026', 3, 3301.6, 1, 8, 8);insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('2/6/2026', 8, 7176.6, 0, 9, 9);insert into Bookings (BookingDate, NumberOfSeats, TotalPrice, IsConfirmed, PassengerId, FlightId) values ('8/4/2025', 2, 1213.4, 1, 10, 10);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Bookings");
        }
    }
}
