using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyG02.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDepartmentsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view EmployeeDepartmentsView
                                with encryption, schemabinding
                                as
                                select d.DepartmentId as [DepartmentId], d. Name as [DepartmentName],e. Id as [EmployeeId], e.Name as [EmployeeName]
                                from dbo.Departments d left outer join dbo.Employees e
                                on d.DepartmentId =e.DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view EmployeeDepartmentsView");
        }
    }
}
