using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class intial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "status_finance_mgt",
                table: "RequestKeys",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "status_Partner_mgt",
                table: "RequestKeys",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientServerSiteNames");

            migrationBuilder.DropTable(
                name: "ClientServerInfos");

            migrationBuilder.AlterColumn<int>(
                name: "status_finance_mgt",
                table: "RequestKeys",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "status_Partner_mgt",
                table: "RequestKeys",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
