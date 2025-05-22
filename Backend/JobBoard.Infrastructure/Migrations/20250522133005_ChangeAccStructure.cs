using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAccStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Users_UserId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobVacancies_Companies_CompanyId",
                table: "JobVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_JobVacancies_SalaryTypes_SalaryTypeId",
                table: "JobVacancies");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "SalaryTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_JobVacancies_SalaryTypeId",
                table: "JobVacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "SalaryTypeId",
                table: "JobVacancies");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.AddColumn<string>(
                name: "SalaryType",
                table: "JobVacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "Account",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CvPath",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Account_UserId",
                table: "JobApplications",
                column: "UserId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobVacancies_Account_CompanyId",
                table: "JobVacancies",
                column: "CompanyId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Account_UserId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobVacancies_Account_CompanyId",
                table: "JobVacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "SalaryType",
                table: "JobVacancies");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CvPath",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "SalaryTypeId",
                table: "JobVacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalaryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CvPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancies_SalaryTypeId",
                table: "JobVacancies",
                column: "SalaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AccountId",
                table: "Admins",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AccountId",
                table: "Companies",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Users_UserId",
                table: "JobApplications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobVacancies_Companies_CompanyId",
                table: "JobVacancies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobVacancies_SalaryTypes_SalaryTypeId",
                table: "JobVacancies",
                column: "SalaryTypeId",
                principalTable: "SalaryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
