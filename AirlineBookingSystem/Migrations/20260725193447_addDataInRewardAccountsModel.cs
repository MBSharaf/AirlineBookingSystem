using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addDataInRewardAccountsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into RewardAccounts (TotalPoints, PassengerId) values (391, 1);insert into RewardAccounts (TotalPoints, PassengerId) values (74, 2);insert into RewardAccounts (TotalPoints, PassengerId) values (601, 3);insert into RewardAccounts (TotalPoints, PassengerId) values (587, 4);insert into RewardAccounts (TotalPoints, PassengerId) values (607, 5);insert into RewardAccounts (TotalPoints, PassengerId) values (783, 6);insert into RewardAccounts (TotalPoints, PassengerId) values (189, 7);insert into RewardAccounts (TotalPoints, PassengerId) values (709, 8);insert into RewardAccounts (TotalPoints, PassengerId) values (842, 9);insert into RewardAccounts (TotalPoints, PassengerId) values (817, 10);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from RewardAccounts");
        }
    }
}
