using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencijaIS181089.Repository.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedLines_Orders_LineId",
                table: "OrderedLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedLines_Lines_OrderId",
                table: "OrderedLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedLines_Reservations_LineId",
                table: "ReservedLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedLines_Lines_ReservationId",
                table: "ReservedLines");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedLines_Lines_LineId",
                table: "OrderedLines",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedLines_Orders_OrderId",
                table: "OrderedLines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedLines_Lines_LineId",
                table: "ReservedLines",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedLines_Reservations_ReservationId",
                table: "ReservedLines",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedLines_Lines_LineId",
                table: "OrderedLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedLines_Orders_OrderId",
                table: "OrderedLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedLines_Lines_LineId",
                table: "ReservedLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedLines_Reservations_ReservationId",
                table: "ReservedLines");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedLines_Orders_LineId",
                table: "OrderedLines",
                column: "LineId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedLines_Lines_OrderId",
                table: "OrderedLines",
                column: "OrderId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedLines_Reservations_LineId",
                table: "ReservedLines",
                column: "LineId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedLines_Lines_ReservationId",
                table: "ReservedLines",
                column: "ReservationId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
