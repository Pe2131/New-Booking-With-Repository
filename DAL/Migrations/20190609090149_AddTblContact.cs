using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddTblContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Slogan",
                table: "Tbl_Settings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "tbl_Contacts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Contacts", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Slogan",
                table: "Tbl_Settings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
