using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abstergo.Migrations
{
    public partial class InitalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    IsFolder = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChildId = table.Column<int>(type: "INTEGER", nullable: false),
                    FavoriteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteLinks_Links_FavoriteId",
                        column: x => x.FavoriteId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteLinks_FavoriteId",
                table: "FavoriteLinks",
                column: "FavoriteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteLinks");

            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
