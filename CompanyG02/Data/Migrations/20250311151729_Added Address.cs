using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyG02.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetaildAddress_BlockNo",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetaildAddress_City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetaildAddress_Country",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetaildAddress_street",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetaildAddress_BlockNo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DetaildAddress_City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DetaildAddress_Country",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DetaildAddress_street",
                table: "Employees");
        }
    }
}
