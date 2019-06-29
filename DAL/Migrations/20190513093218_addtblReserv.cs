using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addtblReserv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Reserve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fullname = table.Column<string>(nullable: false),
                    AgentId = table.Column<string>(nullable: true),
                    PathId = table.Column<int>(nullable: false),
                    ReservedDate = table.Column<DateTime>(nullable: false),
                    Adult = table.Column<int>(nullable: false),
                    Baby = table.Column<int>(nullable: false),
                    SumPrice = table.Column<decimal>(nullable: false),
                    SumCount = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Reserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Reserve_AspNetUsers_AgentId",
                        column: x => x.AgentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Reserve_tbl_PathWays_PathId",
                        column: x => x.PathId,
                        principalTable: "tbl_PathWays",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Reserve_AgentId",
                table: "Tbl_Reserve",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Reserve_PathId",
                table: "Tbl_Reserve",
                column: "PathId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Reserve");
        }
    }
}
