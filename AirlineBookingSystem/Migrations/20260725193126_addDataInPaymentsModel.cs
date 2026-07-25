using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addDataInPaymentsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (1, 942.6, '8/2/2026', 1, 'Visa');insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (2, 3720.3, '8/26/2026', 1, 'Cash');insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (3, 2907.9, '8/23/2026', 1, 'Visa');insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (4, 4244.4, '8/13/2026', 1, 'Visa');insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (5, 4283.4, '8/26/2026', 1, 'Cash');insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (6, 3718.8, '8/25/2026', 0, 'Visa');insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (7, 2098.8, '8/30/2026', 1, 'Cash');insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (8, 1238.5, '8/28/2026', 1, 'Visa');insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (9, 2130.7, '8/11/2026', 1, 'Cash');insert into Payments (BookingId, Amount, PaymentDate, IsPaid, PaymentMethod) values (10, 269.4, '8/6/2026', 0, 'Cash');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Payments");
        }
    }
}
