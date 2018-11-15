using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HydroService.Migrations
{
    public partial class NewBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    BoatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoatName = table.Column<string>(nullable: true),
                    BoatNumber = table.Column<string>(nullable: true),
                    BoatActive = table.Column<bool>(nullable: false),
                    BoatComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.BoatId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientName = table.Column<string>(nullable: true),
                    ClientPhone = table.Column<string>(nullable: true),
                    ClientRegistred = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "BoatSchedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    ScheduleComment = table.Column<string>(nullable: true),
                    BoatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatSchedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_BoatSchedules_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "BoatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayShedules",
                columns: table => new
                {
                    DaySheduleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScheduleId = table.Column<int>(nullable: false),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    ScheduleComment = table.Column<string>(nullable: true),
                    BoatId = table.Column<int>(nullable: false),
                    BoatName = table.Column<string>(nullable: true),
                    BoatNumber = table.Column<string>(nullable: true),
                    BoatActive = table.Column<bool>(nullable: false),
                    BoatComment = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayShedules", x => x.DaySheduleId);
                    table.ForeignKey(
                        name: "FK_DayShedules_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatSchedules_BoatId",
                table: "BoatSchedules",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_DayShedules_ClientId",
                table: "DayShedules",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatSchedules");

            migrationBuilder.DropTable(
                name: "DayShedules");

            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
