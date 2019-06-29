using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddNewtabalsForReserv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_DaysCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DaysCapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_NewReseves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fullname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    AgentId = table.Column<string>(nullable: true),
                    RouteId = table.Column<int>(nullable: false),
                    ReservedDate = table.Column<DateTime>(nullable: false),
                    TripdDate = table.Column<DateTime>(nullable: false),
                    Adult = table.Column<int>(nullable: false),
                    AdultName = table.Column<int>(nullable: false),
                    ChildupTo2 = table.Column<int>(nullable: false),
                    ChildupTo2Name = table.Column<string>(nullable: true),
                    Childup2To7 = table.Column<int>(nullable: false),
                    Childup2To7Names = table.Column<string>(nullable: true),
                    Childup7To12 = table.Column<int>(nullable: false),
                    Childup7To12Names = table.Column<string>(nullable: true),
                    StudentOrRetirs = table.Column<int>(nullable: false),
                    studentOrRetirsName = table.Column<string>(nullable: true),
                    SumPrice = table.Column<decimal>(nullable: false),
                    SumCount = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_NewReseves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_NewReseves_AspNetUsers_AgentId",
                        column: x => x.AgentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_NewReseves_tbl_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "tbl_Routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ReservCounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoutId_FG = table.Column<int>(nullable: false),
                    ReservDate = table.Column<DateTime>(nullable: false),
                    count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ReservCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_ReservCounts_tbl_Routes_RoutId_FG",
                        column: x => x.RoutId_FG,
                        principalTable: "tbl_Routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_NewReseves_AgentId",
                table: "tbl_NewReseves",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_NewReseves_RouteId",
                table: "tbl_NewReseves",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ReservCounts_RoutId_FG",
                table: "tbl_ReservCounts",
                column: "RoutId_FG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DaysCapacities");

            migrationBuilder.DropTable(
                name: "tbl_NewReseves");

            migrationBuilder.DropTable(
                name: "tbl_ReservCounts");
        }
    }
}
