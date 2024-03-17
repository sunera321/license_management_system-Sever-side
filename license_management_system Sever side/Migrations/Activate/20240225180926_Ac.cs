using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations.Activate
{
    public partial class Ac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseKey",
                columns: table => new
                {
                    CID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerMacAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidDateUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modules = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseKey", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "Activate",
                columns: table => new
                {
                    LID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HsenidUser = table.Column<int>(type: "int", nullable: false),
                    HsenidPartner = table.Column<int>(type: "int", nullable: false),
                    CID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activate", x => x.LID);
                    table.ForeignKey(
                        name: "FK_Activate_LicenseKey_CID",
                        column: x => x.CID,
                        principalTable: "LicenseKey",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activate_CID",
                table: "Activate",
                column: "CID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activate");

            migrationBuilder.DropTable(
                name: "LicenseKey");
        }
    }
}
