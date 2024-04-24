using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_License_keys",
                table: "License_keys");

            migrationBuilder.DropColumn(
                name: "key_id",
                table: "License_keys");

            migrationBuilder.AlterColumn<string>(
                name: "Key_name",
                table: "License_keys",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_License_keys",
                table: "License_keys",
                column: "Key_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_License_keys",
                table: "License_keys");

            migrationBuilder.AlterColumn<string>(
                name: "Key_name",
                table: "License_keys",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "key_id",
                table: "License_keys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_License_keys",
                table: "License_keys",
                column: "key_id");
        }
    }
}
