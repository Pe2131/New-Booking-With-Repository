using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditDiscountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSpecific",
                table: "tbl_Discounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PathWays",
                table: "tbl_Discounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSpecific",
                table: "tbl_Discounts");

            migrationBuilder.DropColumn(
                name: "PathWays",
                table: "tbl_Discounts");
        }
    }
}
