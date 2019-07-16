using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DeleteRserveTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Reserve");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Reserve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adult = table.Column<int>(nullable: false),
                    AgentId = table.Column<string>(nullable: true),
                    Baby = table.Column<int>(nullable: false),
                    Fullname = table.Column<string>(nullable: false),
                    PathId = table.Column<int>(nullable: false),
                    ReservedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    SumCount = table.Column<int>(nullable: false),
                    SumPrice = table.Column<decimal>(nullable: false)
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
    }
}
