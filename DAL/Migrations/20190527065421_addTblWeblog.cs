using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addTblWeblog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Weblogs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId_Fk = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Authore = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    KeyWords = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Weblogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_Weblogs_AspNetUsers_UserId_Fk",
                        column: x => x.UserId_Fk,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Weblogs_UserId_Fk",
                table: "tbl_Weblogs",
                column: "UserId_Fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Weblogs");
        }
    }
}
