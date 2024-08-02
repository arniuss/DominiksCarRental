using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DominiksCarRental.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserIdFromReservationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
