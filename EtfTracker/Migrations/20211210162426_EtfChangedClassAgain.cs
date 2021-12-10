using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtfTracker.Migrations
{
    public partial class EtfChangedClassAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EtfType",
                table: "EtfPurchase",
                newName: "EtfTypeID");

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

            migrationBuilder.CreateIndex(
                name: "IX_EtfPurchase_EtfTypeID",
                table: "EtfPurchase",
                column: "EtfTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EtfPurchase_EtfType_EtfTypeID",
                table: "EtfPurchase",
                column: "EtfTypeID",
                principalTable: "EtfType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtfPurchase_EtfType_EtfTypeID",
                table: "EtfPurchase");

            migrationBuilder.DropTable(
                name: "EtfType");

            migrationBuilder.DropIndex(
                name: "IX_EtfPurchase_EtfTypeID",
                table: "EtfPurchase");

            migrationBuilder.RenameColumn(
                name: "EtfTypeID",
                table: "EtfPurchase",
                newName: "EtfType");
        }
    }
}
