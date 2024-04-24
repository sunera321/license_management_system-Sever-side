using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clientId",
                table: "ClientServerInfos");

            migrationBuilder.AddColumn<string>(
                name: "macAddress",
                table: "License_keys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "licenceKey",
                table: "ClientServerInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "macAddress",
                table: "License_keys");

            migrationBuilder.DropColumn(
                name: "licenceKey",
                table: "ClientServerInfos");

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "ClientServerInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
