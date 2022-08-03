using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_WebAPI_Task1.Migrations
{
    public partial class CreatedGameshopsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameshopId",
                table: "VideoGames",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gameshops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PriceRange = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gameshops", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_GameshopId",
                table: "VideoGames",
                column: "GameshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Gameshops_GameshopId",
                table: "VideoGames",
                column: "GameshopId",
                principalTable: "Gameshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Gameshops_GameshopId",
                table: "VideoGames");

            migrationBuilder.DropTable(
                name: "Gameshops");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_GameshopId",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "GameshopId",
                table: "VideoGames");
        }
    }
}
