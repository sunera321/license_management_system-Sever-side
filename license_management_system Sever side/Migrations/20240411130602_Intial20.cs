using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class Intial20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestID",
                table: "LicenseKey",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestKeyRequestID",
                table: "LicenseKey",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseKey_RequestKeyRequestID",
                table: "LicenseKey",
                column: "RequestKeyRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseKey_RequestKeys_RequestKeyRequestID",
                table: "LicenseKey",
                column: "RequestKeyRequestID",
                principalTable: "RequestKeys",
                principalColumn: "request_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseKey_RequestKeys_RequestKeyRequestID",
                table: "LicenseKey");

            migrationBuilder.DropIndex(
                name: "IX_LicenseKey_RequestKeyRequestID",
                table: "LicenseKey");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "LicenseKey");

            migrationBuilder.DropColumn(
                name: "RequestKeyRequestID",
                table: "LicenseKey");
        }
    }
}
