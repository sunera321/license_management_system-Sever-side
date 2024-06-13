using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initila122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_RequestKeys_RequestKeyRequestID",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_RequestKeyRequestID",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "RequestKeyRequestID",
                table: "Modules");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestKeyRequestID",
                table: "Modules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image path",
                table: "Modules",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_RequestKeyRequestID",
                table: "Modules",
                column: "RequestKeyRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_RequestKeys_RequestKeyRequestID",
                table: "Modules",
                column: "RequestKeyRequestID",
                principalTable: "RequestKeys",
                principalColumn: "request_id");
        }
    }
}
