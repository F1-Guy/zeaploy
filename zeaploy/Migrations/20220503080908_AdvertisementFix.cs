using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zeaploy.Migrations
{
    public partial class AdvertisementFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Advertisements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Advertisements");
        }
    }
}
