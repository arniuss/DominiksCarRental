using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DominiksCarRental.Migrations
{
    /// <inheritdoc />
    public partial class CarTypeAddedToCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "CarTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarTypes_CarID",
                table: "CarTypes",
                column: "CarID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarTypes_Cars_CarID",
                table: "CarTypes",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarTypes_Cars_CarID",
                table: "CarTypes");

            migrationBuilder.DropIndex(
                name: "IX_CarTypes_CarID",
                table: "CarTypes");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "CarTypes");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
