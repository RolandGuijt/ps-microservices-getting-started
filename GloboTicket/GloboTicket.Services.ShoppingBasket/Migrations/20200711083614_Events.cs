using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GloboTicket.Services.ShoppingBasket.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_EventId",
                table: "BasketLines",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketLines_Events_EventId",
                table: "BasketLines",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketLines_Events_EventId",
                table: "BasketLines");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_BasketLines_EventId",
                table: "BasketLines");
        }
    }
}
