﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abstergo.Blazor.Migrations
{
    public partial class AddItemColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Links",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Links");
        }
    }
}
