using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditTbldiscountSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisCountFor",
                table: "tbl_DiscountSettings");

            migrationBuilder.RenameColumn(
                name: "percent",
                table: "tbl_DiscountSettings",
                newName: "forStudent");

            migrationBuilder.AddColumn<int>(
                name: "ForChild0",
                table: "tbl_DiscountSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ForChild2",
                table: "tbl_DiscountSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ForChild7",
                table: "tbl_DiscountSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ForTwoWay",
                table: "tbl_DiscountSettings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForChild0",
                table: "tbl_DiscountSettings");

            migrationBuilder.DropColumn(
                name: "ForChild2",
                table: "tbl_DiscountSettings");

            migrationBuilder.DropColumn(
                name: "ForChild7",
                table: "tbl_DiscountSettings");

            migrationBuilder.DropColumn(
                name: "ForTwoWay",
                table: "tbl_DiscountSettings");

            migrationBuilder.RenameColumn(
                name: "forStudent",
                table: "tbl_DiscountSettings",
                newName: "percent");

            migrationBuilder.AddColumn<string>(
                name: "DisCountFor",
                table: "tbl_DiscountSettings",
                nullable: true);
        }
    }
}
