using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DominiksCarRental.Migrations
{
    /// <inheritdoc />
    public partial class NullableCarID : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "CarTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarTypes_Cars_CarID",
                table: "CarTypes");

            migrationBuilder.DropIndex(
                name: "IX_CarTypes_CarID",
                table: "CarTypes");

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "CarTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
