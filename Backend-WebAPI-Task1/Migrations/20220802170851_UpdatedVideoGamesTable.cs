using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_WebAPI_Task1.Migrations
{
    public partial class UpdatedVideoGamesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "VideoGames",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "VideoGames");
        }
    }
}
