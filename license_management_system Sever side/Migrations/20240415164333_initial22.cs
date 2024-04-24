/*using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestKeys_License_Keys_LicenseKeyId",
                table: "RequestKeys");

            migrationBuilder.DropIndex(
                name: "IX_RequestKeys_LicenseKeyId",
                table: "RequestKeys");

            migrationBuilder.DropColumn(
                name: "LicenseKeyId",
                table: "RequestKeys");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "License_Keys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LicenseKeyId",
                table: "RequestKeys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "License_Keys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_LicenseKeyId",
                table: "RequestKeys",
                column: "LicenseKeyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestKeys_License_Keys_LicenseKeyId",
                table: "RequestKeys",
                column: "LicenseKeyId",
                principalTable: "License_Keys",
                principalColumn: "key_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
*/