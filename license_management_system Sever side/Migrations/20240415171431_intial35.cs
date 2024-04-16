using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class intial35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestKeys_Users_PartnerId",
                table: "RequestKeys");

            migrationBuilder.AlterColumn<int>(
                name: "PartnerId",
                table: "RequestKeys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestKeys_Users_PartnerId",
                table: "RequestKeys",
                column: "PartnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestKeys_Users_PartnerId",
                table: "RequestKeys");

            migrationBuilder.AlterColumn<int>(
                name: "PartnerId",
                table: "RequestKeys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestKeys_Users_PartnerId",
                table: "RequestKeys",
                column: "PartnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
