using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProjectASP.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeparture = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    WaitTime = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    CurrentLeg = table.Column<int>(type: "int", nullable: false),
                    NextLegs = table.Column<int>(type: "int", nullable: false),
                    IsChangeStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loggers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegId = table.Column<int>(type: "int", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    GetIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GetOut = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loggers_Legs_LegId",
                        column: x => x.LegId,
                        principalTable: "Legs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Legs",
                columns: new[] { "Id", "CurrentLeg", "FlightId", "IsChangeStatus", "NextLegs", "Number", "WaitTime" },
                values: new object[,]
                {
                    { 1, 1, null, false, 2, 1, 3 },
                    { 2, 2, null, false, 4, 2, 5 },
                    { 3, 4, null, false, 8, 3, 6 },
                    { 4, 8, null, false, 272, 4, 7 },
                    { 5, 16, null, false, 96, 5, 4 },
                    { 6, 32, null, true, 128, 6, 7 },
                    { 7, 64, null, true, 128, 7, 8 },
                    { 8, 128, null, true, 8, 8, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loggers_LegId",
                table: "Loggers",
                column: "LegId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Loggers");

            migrationBuilder.DropTable(
                name: "Legs");
        }
    }
}
