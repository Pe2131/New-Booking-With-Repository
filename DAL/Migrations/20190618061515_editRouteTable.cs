using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class editRouteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeparArriveDays",
                table: "tbl_Routes",
                newName: "ArriveDays");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "tbl_Routes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "tbl_Routes");

            migrationBuilder.RenameColumn(
                name: "ArriveDays",
                table: "tbl_Routes",
                newName: "DeparArriveDays");
        }
    }
}
