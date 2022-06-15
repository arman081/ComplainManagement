using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplainManagement.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplainManagementUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainManagementUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ComplainTypes",
                columns: table => new
                {
                    ComplainTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainTypes", x => x.ComplainTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ComplainAndSolutions",
                columns: table => new
                {
                    ComplainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ComplainDetails = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ComplainStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ComplainTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainAndSolutions", x => x.ComplainId);
                    table.ForeignKey(
                        name: "FK_ComplainAndSolutions_ComplainTypes_ComplainTypeId",
                        column: x => x.ComplainTypeId,
                        principalTable: "ComplainTypes",
                        principalColumn: "ComplainTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComplainTypes",
                columns: new[] { "ComplainTypeId", "ComplainTypeName", "CreatedDate", "IsActive", "LastModifiedOn" },
                values: new object[,]
                {
                    { 1, "Network", new DateTime(2022, 6, 15, 14, 13, 28, 879, DateTimeKind.Local).AddTicks(129), true, null },
                    { 2, "Billing", new DateTime(2022, 6, 15, 14, 13, 28, 880, DateTimeKind.Local).AddTicks(6566), true, null },
                    { 3, "Call Drop", new DateTime(2022, 6, 15, 14, 13, 28, 880, DateTimeKind.Local).AddTicks(6587), true, null },
                    { 4, "Internet", new DateTime(2022, 6, 15, 14, 13, 28, 880, DateTimeKind.Local).AddTicks(6590), true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplainAndSolutions_ComplainTypeId",
                table: "ComplainAndSolutions",
                column: "ComplainTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplainManagementUsers_UserEmail",
                table: "ComplainManagementUsers",
                column: "UserEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplainManagementUsers_UserName",
                table: "ComplainManagementUsers",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplainAndSolutions");

            migrationBuilder.DropTable(
                name: "ComplainManagementUsers");

            migrationBuilder.DropTable(
                name: "ComplainTypes");
        }
    }
}
