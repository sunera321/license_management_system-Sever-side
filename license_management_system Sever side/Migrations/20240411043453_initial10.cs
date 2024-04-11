using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "ClientServerInfos",
                columns: table => new
                {
                    MacAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HostUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    testDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServerInfos", x => x.MacAddress);
                });

            migrationBuilder.CreateTable(
                name: "ModuleEndClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModulesId = table.Column<int>(type: "int", nullable: false),
                    EndClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleEndClient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleEndClient_EndClients_EndClientId",
                        column: x => x.EndClientId,
                        principalTable: "EndClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleEndClient_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientServerSiteNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientServerMacAddress = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServerSiteNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientServerSiteNames_ClientServerInfos_ClientServerMacAddress",
                        column: x => x.ClientServerMacAddress,
                        principalTable: "ClientServerInfos",
                        principalColumn: "MacAddress");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientServerSiteNames_ClientServerMacAddress",
                table: "ClientServerSiteNames",
                column: "ClientServerMacAddress");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleEndClient_EndClientId",
                table: "ModuleEndClient",
                column: "EndClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleEndClient_ModulesId",
                table: "ModuleEndClient",
                column: "ModulesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientServerSiteNames");

            migrationBuilder.DropTable(
                name: "ModuleEndClient");

            migrationBuilder.DropTable(
                name: "ClientServerInfos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Partner_discription",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LicenseKeyId",
                table: "RequestKeys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_LicenseKeyId",
                table: "RequestKeys",
                column: "LicenseKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestKeys_LicenseKey_LicenseKeyId",
                table: "RequestKeys",
                column: "LicenseKeyId",
                principalTable: "LicenseKey",
                principalColumn: "key_id");
        }
    }
}
