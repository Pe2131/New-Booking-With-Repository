using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Province",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
