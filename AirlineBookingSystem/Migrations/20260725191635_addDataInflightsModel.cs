using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addDataInflightsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG517', '9/25/2027', '8/17/2025', 206.6, 57.0, 125.2, 1, 1, 1, 1);insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG718', '7/3/2025', '4/5/2026', 521.1, 3.7, 279.4, 0, 2, 2, 2);insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG215', '3/22/2025', '7/23/2026', 264.5, 55.7, 144.9, 1, 3, 3, 3);insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG931', '6/21/2025', '12/19/2027', 807.0, 99.9, 212.2, 0, 4, 4, 4);insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG442', '7/7/2027', '8/26/2025', 226.1, 84.3, 158.3, 0, 5, 5, 5);insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG603', '4/13/2027', '4/16/2025', 716.3, 13.5, 32.2, 1, 6, 6, 6);insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG995', '6/27/2025', '10/19/2027', 337.9, 60.3, 8.2, 1, 7, 7, 7);insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG442', '9/6/2027', '6/28/2026', 716.9, 52.8, 175.0, 1, 8, 8, 8);insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG442', '1/23/2026', '10/22/2026', 181.3, 15.7, 315.3, 0, 9, 9, 9);insert into Flights (FlightNumber, DepartureTime, ArrivalTime, DistanceInKM, PricePerKM, AvailableSeats, IsAvailable, DepartureAirportId, ArrivalAirportId, HotelId) values ('EG328', '1/30/2026', '4/2/2027', 542.8, 6.5, 438.6, 1, 10, 10, 10);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Flights");
        }
    }
}
