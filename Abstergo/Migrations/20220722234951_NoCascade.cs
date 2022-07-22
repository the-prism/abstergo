using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abstergo.Migrations
{
    public partial class NoCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteLinks_Links_FavoriteId",
                table: "FavoriteLinks");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteLinks_Links_FavoriteId",
                table: "FavoriteLinks",
                column: "FavoriteId",
                principalTable: "Links",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteLinks_Links_FavoriteId",
                table: "FavoriteLinks");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteLinks_Links_FavoriteId",
                table: "FavoriteLinks",
                column: "FavoriteId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
