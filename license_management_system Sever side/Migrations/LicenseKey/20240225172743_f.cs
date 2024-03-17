using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations.LicenseKey
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseKeys",
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
                    table.PrimaryKey("PK_LicenseKeys", x => x.CID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseKeys");
        }
    }
}
