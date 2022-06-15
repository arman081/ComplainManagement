using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplainManagement.MVC.Migrations
{
    public partial class complainsolutiondateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Solution",
                table: "ComplainAndSolutions",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647);

            migrationBuilder.AlterColumn<string>(
                name: "ComplainStatus",
                table: "ComplainAndSolutions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "ComplainDate",
                table: "ComplainAndSolutions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainNo",
                table: "ComplainAndSolutions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SolutionDate",
                table: "ComplainAndSolutions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComplainEntryVm",
                columns: table => new
                {
                    ComplainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ComplainDetails = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ComplainTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainEntryVm", x => x.ComplainId);
                    table.ForeignKey(
                        name: "FK_ComplainEntryVm_ComplainTypes_ComplainTypeId",
                        column: x => x.ComplainTypeId,
                        principalTable: "ComplainTypes",
                        principalColumn: "ComplainTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplainEntryVm_ComplainTypeId",
                table: "ComplainEntryVm",
                column: "ComplainTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplainEntryVm");

            migrationBuilder.DropColumn(
                name: "ComplainDate",
                table: "ComplainAndSolutions");

            migrationBuilder.DropColumn(
                name: "ComplainNo",
                table: "ComplainAndSolutions");

            migrationBuilder.DropColumn(
                name: "SolutionDate",
                table: "ComplainAndSolutions");

            migrationBuilder.AlterColumn<string>(
                name: "Solution",
                table: "ComplainAndSolutions",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComplainStatus",
                table: "ComplainAndSolutions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
