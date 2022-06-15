using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplainManagement.MVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplainTypes",
                columns: table => new
                {
                    ComplainTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainTypes", x => x.ComplainTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
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
                    ComplainTypeId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "ComplainTypeId", "ComplainTypeName" },
                values: new object[,]
                {
                    { 1, "Network" },
                    { 2, "Billing" },
                    { 3, "Call Drop" },
                    { 4, "Internet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplainAndSolutions_ComplainTypeId",
                table: "ComplainAndSolutions",
                column: "ComplainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplainAndSolutions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ComplainTypes");
        }
    }
}
