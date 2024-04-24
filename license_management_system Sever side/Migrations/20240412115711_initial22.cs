/*using Microsoft.EntityFrameworkCore.Migrations;

namespace license_management_system_Sever_side.Migrations
{
    public partial class UpdateRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestKeys_Users_PartnerId",
                table: "RequestKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicenseKey",
                table: "LicenseKey");

            migrationBuilder.RenameTable(
                name: "LicenseKey",
                newName: "LicenseKeys");

            migrationBuilder.AlterColumn<int>(
                name: "PartnerId",
                table: "RequestKeys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "LicenseKeys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicenseKeys",
                table: "LicenseKeys",
                column: "key_id");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseKeys_RequestId",
                table: "LicenseKeys",
                column: "RequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseKeys_RequestKeys_RequestId",
                table: "LicenseKeys",
                column: "RequestId",
                principalTable: "RequestKeys",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestKeys_Users_PartnerId",
                table: "RequestKeys",
                column: "PartnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseKeys_RequestKeys_RequestId",
                table: "LicenseKeys");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestKeys_Users_PartnerId",
                table: "RequestKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicenseKeys",
                table: "LicenseKeys");

            migrationBuilder.DropIndex(
                name: "IX_LicenseKeys_RequestId",
                table: "LicenseKeys");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "LicenseKeys");

            migrationBuilder.RenameTable(
                name: "LicenseKeys",
                newName: "LicenseKey");

            migrationBuilder.AlterColumn<int>(
                name: "PartnerId",
                table: "RequestKeys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicenseKey",
                table: "LicenseKey",
                column: "key_id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestKeys_Users_PartnerId",
                table: "RequestKeys",
                column: "PartnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
*/