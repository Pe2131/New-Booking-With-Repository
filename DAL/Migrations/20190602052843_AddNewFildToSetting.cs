using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddNewFildToSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutImag1",
                table: "Tbl_Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutImag2",
                table: "Tbl_Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slogan",
                table: "Tbl_Settings",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutImag1",
                table: "Tbl_Settings");

            migrationBuilder.DropColumn(
                name: "AboutImag2",
                table: "Tbl_Settings");

            migrationBuilder.DropColumn(
                name: "Slogan",
                table: "Tbl_Settings");
        }
    }
}
