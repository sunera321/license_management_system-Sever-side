using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class addclintseverdtl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeverMacAd",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientServers",
                columns: table => new
                {
                    MacAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HostUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServers", x => x.MacAddress);
                });

            migrationBuilder.CreateTable(
                name: "ClientServerSiteNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServerSiteNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientServerSiteNames_ClientServers_MacAddress",
                        column: x => x.MacAddress,
                        principalTable: "ClientServers",
                        principalColumn: "MacAddress");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MacAddress",
                table: "Clients",
                column: "MacAddress",
                unique: true,
                filter: "[MacAddress] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServerSiteNames_MacAddress",
                table: "ClientServerSiteNames",
                column: "MacAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientServers_MacAddress",
                table: "Clients",
                column: "MacAddress",
                principalTable: "ClientServers",
                principalColumn: "MacAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientServers_MacAddress",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "ClientServerSiteNames");

            migrationBuilder.DropTable(
                name: "ClientServers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_MacAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "SeverMacAd",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
