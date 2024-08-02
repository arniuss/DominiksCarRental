using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DominiksCarRental.Migrations
{
    /// <inheritdoc />
    public partial class AddedCarTypeIdToCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarTypes_Cars_CarID",
                table: "CarTypes");

            migrationBuilder.DropIndex(
                name: "IX_CarTypes_CarID",
                table: "CarTypes");

            migrationBuilder.AddColumn<int>(
                name: "CarTypeId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars",
                column: "CarTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "CarTypes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarTypeId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_CarTypes_CarID",
                table: "CarTypes",
                column: "CarID",
                unique: true,
                filter: "[CarID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CarTypes_Cars_CarID",
                table: "CarTypes",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
