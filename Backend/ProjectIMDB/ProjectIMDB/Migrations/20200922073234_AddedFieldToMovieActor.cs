using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectIMDB.Migrations
{
    public partial class AddedFieldToMovieActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStar",
                table: "MovieActor",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStar",
                table: "MovieActor");
        }
    }
}
