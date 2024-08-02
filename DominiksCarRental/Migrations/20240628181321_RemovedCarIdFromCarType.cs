using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DominiksCarRental.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCarIdFromCarType : Migration
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

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "CarTypes");

            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TypeID",
                table: "Cars",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_TypeID",
                table: "Cars",
                column: "TypeID",
                principalTable: "CarTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_TypeID",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TypeID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TypeID",
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
    }
}
