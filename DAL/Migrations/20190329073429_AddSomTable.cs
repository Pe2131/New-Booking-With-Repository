using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddSomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Factore_Tbl_PathWay_PathwayId_FG",
                table: "Tbl_Factore");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Factore_AspNetUsers_UserId_FG",
                table: "Tbl_Factore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_PathWay",
                table: "Tbl_PathWay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Factore",
                table: "Tbl_Factore");

            migrationBuilder.RenameTable(
                name: "Tbl_PathWay",
                newName: "tbl_PathWays");

            migrationBuilder.RenameTable(
                name: "Tbl_Factore",
                newName: "tbl_Factores");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Factore_UserId_FG",
                table: "tbl_Factores",
                newName: "IX_tbl_Factores_UserId_FG");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Factore_PathwayId_FG",
                table: "tbl_Factores",
                newName: "IX_tbl_Factores_PathwayId_FG");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_PathWays",
                table: "tbl_PathWays",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Factores",
                table: "tbl_Factores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tbl_Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Percent = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Country_FG = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Cities_tbl_Countries_Country_FG",
                        column: x => x.Country_FG,
                        principalTable: "tbl_Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Cities_Country_FG",
                table: "tbl_Cities",
                column: "Country_FG");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Factores_tbl_PathWays_PathwayId_FG",
                table: "tbl_Factores",
                column: "PathwayId_FG",
                principalTable: "tbl_PathWays",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Factores_AspNetUsers_UserId_FG",
                table: "tbl_Factores",
                column: "UserId_FG",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Factores_tbl_PathWays_PathwayId_FG",
                table: "tbl_Factores");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Factores_AspNetUsers_UserId_FG",
                table: "tbl_Factores");

            migrationBuilder.DropTable(
                name: "tbl_Cities");

            migrationBuilder.DropTable(
                name: "tbl_Discounts");

            migrationBuilder.DropTable(
                name: "tbl_Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_PathWays",
                table: "tbl_PathWays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Factores",
                table: "tbl_Factores");

            migrationBuilder.RenameTable(
                name: "tbl_PathWays",
                newName: "Tbl_PathWay");

            migrationBuilder.RenameTable(
                name: "tbl_Factores",
                newName: "Tbl_Factore");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Factores_UserId_FG",
                table: "Tbl_Factore",
                newName: "IX_Tbl_Factore_UserId_FG");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Factores_PathwayId_FG",
                table: "Tbl_Factore",
                newName: "IX_Tbl_Factore_PathwayId_FG");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_PathWay",
                table: "Tbl_PathWay",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Factore",
                table: "Tbl_Factore",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Factore_Tbl_PathWay_PathwayId_FG",
                table: "Tbl_Factore",
                column: "PathwayId_FG",
                principalTable: "Tbl_PathWay",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Factore_AspNetUsers_UserId_FG",
                table: "Tbl_Factore",
                column: "UserId_FG",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
