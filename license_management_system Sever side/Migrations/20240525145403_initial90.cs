using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initial90 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClintEmail",
                table: "Loging_Validetion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClintName",
                table: "Loging_Validetion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PartnerEmail",
                table: "Loging_Validetion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PartnerName",
                table: "Loging_Validetion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClintEmail",
                table: "Loging_Validetion");

            migrationBuilder.DropColumn(
                name: "ClintName",
                table: "Loging_Validetion");

            migrationBuilder.DropColumn(
                name: "PartnerEmail",
                table: "Loging_Validetion");

            migrationBuilder.DropColumn(
                name: "PartnerName",
                table: "Loging_Validetion");
        }
    }
}
