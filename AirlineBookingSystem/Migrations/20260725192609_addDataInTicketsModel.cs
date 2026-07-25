using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addDataInTicketsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('KE4188', 2125.34, '8/6/2026', 1);insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('AA3211', 2594.76, '8/2/2026', 2);insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('QR2001', 666.21, '8/7/2026', 3);insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('SA4674', 934.07, '8/2/2026', 4);insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('ET3060', 3394.16, '8/2/2026', 5);insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('SA7016', 1306.27, '8/9/2026', 6);insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('EK8073', 4458.17, '8/7/2026', 7);insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('SK7103', 3058.54, '8/4/2026', 8);insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('WN2179', 2788.89, '8/2/2026', 9);insert into Tickets (TicketNumber, TicketPrice, IssueDate, BookingId) values ('TG7094', 2648.19, '8/5/2026', 10);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Tickets");
        }
    }
}
