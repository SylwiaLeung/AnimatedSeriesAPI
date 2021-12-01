using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimatedSeriesAPI.Migrations
{
    public partial class changePropertyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Seasons",
                newName: "SeasonNumber");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Episodes",
                newName: "EpisodeNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeasonNumber",
                table: "Seasons",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "EpisodeNumber",
                table: "Episodes",
                newName: "Number");
        }
    }
}
