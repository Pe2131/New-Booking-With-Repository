using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditReservTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdultName",
                table: "tbl_NewReseves",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AdultName",
                table: "tbl_NewReseves",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
