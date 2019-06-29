using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditTblSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CopyRight",
                table: "Tbl_Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Tbl_Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "facebook",
                table: "Tbl_Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "instagrm",
                table: "Tbl_Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "linkedin",
                table: "Tbl_Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "twitter",
                table: "Tbl_Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopyRight",
                table: "Tbl_Settings");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Tbl_Settings");

            migrationBuilder.DropColumn(
                name: "facebook",
                table: "Tbl_Settings");

            migrationBuilder.DropColumn(
                name: "instagrm",
                table: "Tbl_Settings");

            migrationBuilder.DropColumn(
                name: "linkedin",
                table: "Tbl_Settings");

            migrationBuilder.DropColumn(
                name: "twitter",
                table: "Tbl_Settings");
        }
    }
}
