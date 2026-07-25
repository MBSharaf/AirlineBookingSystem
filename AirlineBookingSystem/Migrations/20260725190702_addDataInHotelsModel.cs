using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addDataInHotelsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.', 'Hurghada', 'Cairo', 2.4, 'Hotel5.jpg');insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Donec vitae nisi.', 'Sharm El Sheikh', 'Dahab', 3.7, 'Hotel7.jpg');insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Fusce consequat.', 'Hurghada', 'Safaga', 3.5, 'Hotel8.jpg');insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Donec dapibus.', 'Assuit', 'Assuit', 2.2, 'Hotel4.jpg');insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Aliquam non mauris.', 'Dahab', 'Dahab', 4.3, 'Hotel6.jpg');insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Curabitur at ipsum ac tellus semper interdum.', 'Hurghada', 'Hurghada', 1.2, 'Hotel1.jpg');insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Ut tellus.', 'Alexandria', 'Gouna', 4.3, 'Hotel6.jpg');insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Praesent blandit lacinia erat.', 'Maadi', 'Cairo', 1.6, 'Hotel2.jpg');insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Proin interdum mauris non ligula pellentesque ultrices.', 'El Alamein', 'ElAlamein', 1.5, 'Hotel5.jpg');insert into Hotels (Name, Description, City, Address, Rate, Image) values ('error: undefined method `first'' for nil:NilClass', 'Vestibulum rutrum rutrum neque.', 'Luxor', 'Luxor', 1.9, 'Hotel3.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Hotels");
        }
    }
}
