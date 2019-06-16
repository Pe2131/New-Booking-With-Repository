using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "tbl_Countries",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "tbl_Countries");
        }
    }
}
