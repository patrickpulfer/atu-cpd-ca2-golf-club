using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Golf_Club_Management.Migrations
{
    /// <inheritdoc />
    public partial class ConvertDateTimefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "teeTimes",
                newName: "Slot");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "teeTimes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "teeTimes");

            migrationBuilder.RenameColumn(
                name: "Slot",
                table: "teeTimes",
                newName: "Time");
        }
    }
}
