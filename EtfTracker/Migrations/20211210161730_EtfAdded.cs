using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtfTracker.Migrations
{
    public partial class EtfAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EtfType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtfType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EtfPurchase",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EurPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EtfTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtfPurchase", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EtfPurchase_EtfType_EtfTypeID",
                        column: x => x.EtfTypeID,
                        principalTable: "EtfType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtfPurchase_EtfTypeID",
                table: "EtfPurchase",
                column: "EtfTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtfPurchase");

            migrationBuilder.DropTable(
                name: "EtfType");
        }
    }
}
