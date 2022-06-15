using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplainManagement.API.Migrations
{
    public partial class userpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ComplainManagementUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ComplainTypes",
                keyColumn: "ComplainTypeId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 15, 14, 28, 2, 382, DateTimeKind.Local).AddTicks(8476));

            migrationBuilder.UpdateData(
                table: "ComplainTypes",
                keyColumn: "ComplainTypeId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 15, 14, 28, 2, 383, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "ComplainTypes",
                keyColumn: "ComplainTypeId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 15, 14, 28, 2, 383, DateTimeKind.Local).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "ComplainTypes",
                keyColumn: "ComplainTypeId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 15, 14, 28, 2, 383, DateTimeKind.Local).AddTicks(7754));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "ComplainManagementUsers");

            migrationBuilder.UpdateData(
                table: "ComplainTypes",
                keyColumn: "ComplainTypeId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 15, 14, 13, 28, 879, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "ComplainTypes",
                keyColumn: "ComplainTypeId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 15, 14, 13, 28, 880, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "ComplainTypes",
                keyColumn: "ComplainTypeId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 15, 14, 13, 28, 880, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "ComplainTypes",
                keyColumn: "ComplainTypeId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 15, 14, 13, 28, 880, DateTimeKind.Local).AddTicks(6590));
        }
    }
}
