using Microsoft.EntityFrameworkCore.Migrations;

namespace Insta.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    TotalMediaCount = table.Column<int>(nullable: false),
                    ParsedPostCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HashTags = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    LocationName = table.Column<string>(nullable: true),
                    LocationCountry = table.Column<string>(nullable: true),
                    AccountInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posts_AccountInfo_AccountInfoID",
                        column: x => x.AccountInfoID,
                        principalTable: "AccountInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AccountInfoID",
                table: "Posts",
                column: "AccountInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AccountInfo");
        }
    }
}
