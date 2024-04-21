using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<int>(
                name: "PartnerId",
                table: "RequestKeys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Clint Id",
                table: "License_keys",
                type: "int",
                nullable: true);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestKeys_Users_PartnerId",
                table: "RequestKeys");

            migrationBuilder.DropColumn(
                name: "Clint Id",
                table: "License_keys");

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
