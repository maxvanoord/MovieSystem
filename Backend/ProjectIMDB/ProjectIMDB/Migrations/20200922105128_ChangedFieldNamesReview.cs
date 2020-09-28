using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectIMDB.Migrations
{
    public partial class ChangedFieldNamesReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Reviews");

            migrationBuilder.AddColumn<bool>(
                name: "Rating",
                table: "Reviews",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
