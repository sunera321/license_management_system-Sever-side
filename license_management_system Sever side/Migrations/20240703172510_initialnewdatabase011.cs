using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    /// <inheritdoc />
    public partial class initialnewdatabase011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientLicenseInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KeyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ClientServerInfos",
                columns: table => new
                {
                    MacAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HostUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    licenceKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    testDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServerInfos", x => x.MacAddress);
                });

            migrationBuilder.CreateTable(
                name: "Loging_Validetion",
                columns: table => new
                {
                    LogKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogLicenseKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClintId = table.Column<int>(type: "int", nullable: true),
                    ClintName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClintEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogMacAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogHostUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: true),
                    PartnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loging_Validetion", x => x.LogKey);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    imagepath = table.Column<string>(name: "image path", type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    createddata = table.Column<DateTime>(name: "created data", type: "datetime2", nullable: false),
                    features = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    moduledescription = table.Column<string>(name: "module description", type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    coduleCost = table.Column<float>(name: "codule Cost", type: "real", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleStatistics",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinaceManager_discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinaceManager_UserRole = table.Column<int>(type: "int", nullable: true),
                    Partner_UserRole = table.Column<int>(type: "int", nullable: true),
                    discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientServerSiteNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientServerMacAddress = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServerSiteNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientServerSiteNames_ClientServerInfos_ClientServerMacAddress",
                        column: x => x.ClientServerMacAddress,
                        principalTable: "ClientServerInfos",
                        principalColumn: "MacAddress");
                });

            migrationBuilder.CreateTable(
                name: "EndClients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndClients", x => x.id);
                    table.ForeignKey(
                        name: "FK_EndClients_Users_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndClientModules",
                columns: table => new
                {
                    EndClientId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndClientModules", x => new { x.EndClientId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_EndClientModules_EndClients_EndClientId",
                        column: x => x.EndClientId,
                        principalTable: "EndClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndClientModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestKeys",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_finance_mgt = table.Column<bool>(type: "bit", nullable: false),
                    status_Partner_mgt = table.Column<bool>(type: "bit", nullable: false),
                    issued = table.Column<bool>(type: "bit", nullable: false),
                    comment_finace_mgt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    comment_partner_mgt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    EndClientId = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    FinaceManagerId = table.Column<int>(type: "int", nullable: true),
                    PartnerManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestKeys", x => x.request_id);
                    table.ForeignKey(
                        name: "FK_RequestKeys_EndClients_EndClientId",
                        column: x => x.EndClientId,
                        principalTable: "EndClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RequestKeys_Users_FinaceManagerId",
                        column: x => x.FinaceManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestKeys_Users_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RequestKeys_Users_PartnerManagerID",
                        column: x => x.PartnerManagerID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "License_keys",
                columns: table => new
                {
                    Key_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    activation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deactivated_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    macAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    key_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClintId = table.Column<int>(name: "Clint Id", type: "int", nullable: true),
                    ClintName = table.Column<string>(name: "Clint Name", type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License_keys", x => x.Key_name);
                    table.ForeignKey(
                        name: "FK_License_keys_RequestKeys_RequestId",
                        column: x => x.RequestId,
                        principalTable: "RequestKeys",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientServerSiteNames_ClientServerMacAddress",
                table: "ClientServerSiteNames",
                column: "ClientServerMacAddress");

            migrationBuilder.CreateIndex(
                name: "IX_EndClientModules_ModuleId",
                table: "EndClientModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_EndClients_PartnerId",
                table: "EndClients",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_License_keys_RequestId",
                table: "License_keys",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_EndClientId",
                table: "RequestKeys",
                column: "EndClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_FinaceManagerId",
                table: "RequestKeys",
                column: "FinaceManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_PartnerId",
                table: "RequestKeys",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestKeys_PartnerManagerID",
                table: "RequestKeys",
                column: "PartnerManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientLicenseInfo");

            migrationBuilder.DropTable(
                name: "ClientServerSiteNames");

            migrationBuilder.DropTable(
                name: "EndClientModules");

            migrationBuilder.DropTable(
                name: "License_keys");

            migrationBuilder.DropTable(
                name: "Loging_Validetion");

            migrationBuilder.DropTable(
                name: "ModuleStatistics");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ClientServerInfos");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "RequestKeys");

            migrationBuilder.DropTable(
                name: "EndClients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
