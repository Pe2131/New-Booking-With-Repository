using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RemoveTimeFromPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "tbl_PathWays");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "tbl_PathWays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArrivalTime",
                table: "tbl_PathWays",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "tbl_PathWays",
                nullable: false,
                defaultValue: "");
        }
    }
}
