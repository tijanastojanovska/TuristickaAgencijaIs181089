using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencijaIS181089.Repository.Data.Migrations
{
    public partial class image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LineImage",
                table: "Lines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineImage",
                table: "Lines");
        }
    }
}
