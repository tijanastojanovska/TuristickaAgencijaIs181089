using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencijaIS181089.Repository.Data.Migrations
{
    public partial class imageDest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationImage",
                table: "Destinations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationImage",
                table: "Destinations");
        }
    }
}
