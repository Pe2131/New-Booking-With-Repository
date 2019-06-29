using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditPathway2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tbl_PathWays");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tbl_PathWays",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tbl_PathWays");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tbl_PathWays",
                nullable: false,
                defaultValue: false);
        }
    }
}
