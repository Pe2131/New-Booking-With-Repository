using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addRoutesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Routes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Source_FG = table.Column<int>(nullable: false),
                    Destination_FG = table.Column<int>(nullable: false),
                    DepartureDays = table.Column<string>(nullable: false),
                    DepartureTime = table.Column<string>(nullable: false),
                    DeparArriveDays = table.Column<string>(nullable: false),
                    ArriveTime = table.Column<string>(nullable: false),
                    SourceStation = table.Column<string>(nullable: false),
                    DestStation = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Routes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Routes");
        }
    }
}
