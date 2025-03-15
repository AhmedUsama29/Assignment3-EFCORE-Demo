using CompanyG02.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompanyG02.Data.DataSeed
{
    static class CompanyDBContextSeed
    {

        public static void Seed(CompanyDBContext companyDBContext)
        {

            if (!companyDBContext.Departments.Any())
            {
                var departmentsData = File.ReadAllText("C:\\Users\\ahmed\\OneDrive\\Desktop\\Assignment2-EFCORE-Demo-master\\CompanyG02\\Data\\DataSeed\\departments.json");
                var departments = JsonSerializer.Deserialize<List<Department>>(departmentsData);

                if (departments?.Count > 0)
                {
                    foreach (var department in departments)
                    {
                        companyDBContext.Departments.Add(department);
                    }
                    companyDBContext.SaveChanges();
                } 
            }

            if (!companyDBContext.Employees.Any())
            {
                var employeeData = File.ReadAllText("C:\\Users\\ahmed\\OneDrive\\Desktop\\Assignment2-EFCORE-Demo-master\\CompanyG02\\Data\\DataSeed\\employees.json");
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeeData);

                if (employees?.Count > 0)
                {
                    foreach (var emp in employees)
                    {
                        companyDBContext.Employees.Add(emp);
                    }
                    companyDBContext.SaveChanges();
                }
            }
        }

    }
}
