using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Features",
                table: "Modules",
                newName: "features");

            migrationBuilder.RenameColumn(
                name: "ModuleDescription",
                table: "Modules",
                newName: "module description");

            migrationBuilder.RenameColumn(
                name: "CreatedData",
                table: "Modules",
                newName: "created data");

            migrationBuilder.AlterColumn<string>(
                name: "features",
                table: "Modules",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "module description",
                table: "Modules",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "image path",
                table: "Modules",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image path",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "features",
                table: "Modules",
                newName: "Features");

            migrationBuilder.RenameColumn(
                name: "module description",
                table: "Modules",
                newName: "ModuleDescription");

            migrationBuilder.RenameColumn(
                name: "created data",
                table: "Modules",
                newName: "CreatedData");

            migrationBuilder.AlterColumn<string>(
                name: "Features",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleDescription",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
