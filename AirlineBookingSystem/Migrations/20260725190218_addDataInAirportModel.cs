using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addDataInAirportModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Airports (Name, City, Code) values ('AlameinAirport', 'Marsa', 'ATZ');insert into Airports (Name, City, Code) values ('AswanAirport', 'Aswan', 'HMB');insert into Airports (Name, City, Code) values ('AssiutAirport', 'Assiut', 'CAI');insert into Airports (Name, City, Code) values ('SohagAirport', 'Sohag', 'DBB');insert into Airports (Name, City, Code) values ('CairoAirport', 'Cairo', 'ATZ');insert into Airports (Name, City, Code) values ('ElGounaAirport', 'Gouna', 'SSH');insert into Airports (Name, City, Code) values ('HurghadaAirport', 'Hurghada', 'HBE');insert into Airports (Name, City, Code) values ('LuxorAirport', 'Luxor', 'RMF');insert into Airports (Name, City, Code) values ('AlexandriaAirport', 'Alexandria', 'LXR');insert into Airports (Name, City, Code) values ('SharmAirport', 'Sharm', 'LXR');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Airports");
        }
    }
}
