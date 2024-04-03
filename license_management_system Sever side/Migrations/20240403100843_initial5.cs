using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HostUrl",
                table: "RequestKeys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MackAddress",
                table: "RequestKeys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostUrl",
                table: "EndClients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MackAddress",
                table: "EndClients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostUrl",
                table: "RequestKeys");

            migrationBuilder.DropColumn(
                name: "MackAddress",
                table: "RequestKeys");

            migrationBuilder.DropColumn(
                name: "HostUrl",
                table: "EndClients");

            migrationBuilder.DropColumn(
                name: "MackAddress",
                table: "EndClients");
        }
    }
}
