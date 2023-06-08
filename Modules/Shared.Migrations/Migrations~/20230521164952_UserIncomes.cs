using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shared.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UserIncomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseType",
                schema: "public",
                table: "UserIncomes",
                newName: "IncomeType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IncomeType",
                schema: "public",
                table: "UserIncomes",
                newName: "ExpenseType");
        }
    }
}
