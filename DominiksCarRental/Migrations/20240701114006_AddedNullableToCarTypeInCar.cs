using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DominiksCarRental.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullableToCarTypeInCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "CarTypes");

            migrationBuilder.RenameColumn(
                name: "CarTypeId",
                table: "Cars",
                newName: "CarTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars",
                newName: "IX_Cars_CarTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_CarTypeID",
                table: "Cars",
                column: "CarTypeID",
                principalTable: "CarTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_CarTypeID",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CarTypeID",
                table: "Cars",
                newName: "CarTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CarTypeID",
                table: "Cars",
                newName: "IX_Cars_CarTypeId");

            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "CarTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "CarTypes",
                principalColumn: "ID");
        }
    }
}
