using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class add_loging_valication_table10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Loging_Validetion",
                columns: table => new
                {
                    LogKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogLicenseKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClintId = table.Column<int>(type: "int", nullable: true),
                    LogMacAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogHostUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loging_Validetion", x => x.LogKey);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "Key_Log_Infos",
                columns: table => new
                {
                    LogKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClintId = table.Column<int>(type: "int", nullable: true),
                    LogHostUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogLicenseKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogMacAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: true),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key_Log_Infos", x => x.LogKey);
                });
        }
    }
}
