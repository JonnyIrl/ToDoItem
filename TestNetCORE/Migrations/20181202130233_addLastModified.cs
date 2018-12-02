using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestNetCORE.Migrations
{
    public partial class addLastModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Tasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeModified",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastTimeModified",
                table: "Tasks");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Tasks",
                nullable: false,
                defaultValue: false);
        }
    }
}
