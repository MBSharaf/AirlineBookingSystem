using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addDataInPassengersModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Passengers (FullName, Email, PhoneNumber) values ('Hale Dachs', 'hdachs0@utexas.edu', '771-489-5846');insert into Passengers (FullName, Email, PhoneNumber) values ('Elissa Kitchingham', 'ekitchingham1@taobao.com', '841-706-1884');insert into Passengers (FullName, Email, PhoneNumber) values ('Demetris Meiningen', 'dmeiningen2@163.com', '786-650-4606');insert into Passengers (FullName, Email, PhoneNumber) values ('Sile Crunkhorn', 'scrunkhorn3@smh.com.au', '241-502-6815');insert into Passengers (FullName, Email, PhoneNumber) values ('Nap Dorkin', 'ndorkin4@fc2.com', '946-897-3285');insert into Passengers (FullName, Email, PhoneNumber) values ('Brandy MacFadzean', 'bmacfadzean5@blog.com', '156-877-0098');insert into Passengers (FullName, Email, PhoneNumber) values ('Ole Mayworth', 'omayworth6@e-recht24.de', '575-133-2867');insert into Passengers (FullName, Email, PhoneNumber) values ('Con Filipiak', 'cfilipiak7@cmu.edu', '717-331-5891');insert into Passengers (FullName, Email, PhoneNumber) values ('Spencer Flight', 'sflight8@w3.org', '601-580-7096');insert into Passengers (FullName, Email, PhoneNumber) values ('Martie Pashe', 'mpashe9@free.fr', '822-814-0925');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Passengers");
        }
    }
}
