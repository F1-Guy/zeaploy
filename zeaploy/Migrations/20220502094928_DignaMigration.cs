using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zeaploy.Migrations
{
    public partial class DignaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobType",
                table: "Advertisements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Advertisements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Posted",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Wage",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobType",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "Posted",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "Wage",
                table: "Advertisements");
        }
    }
}
