﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DominiksCarRental.Migrations
{
    /// <inheritdoc />
    public partial class AddedMainImageToCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Cars");
        }
    }
}
