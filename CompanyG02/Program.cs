using CompanyG02.Data;
using CompanyG02.Data.DataSeed;
using CompanyG02.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyG02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (CompanyDBContext companyDBContext = new CompanyDBContext())
            {

                #region Add
                //Employee emp01 = new Employee() { Name = "Nada", Age = 26, Salary = 9_000, Email = "Nada@gmail.com" };
                //Employee emp02 = new Employee() {Id=1,  Name = "Rana", Age = 26, Salary = 8_000, Email = "Rana@gmail.com" };

                //Console.WriteLine(companyDBContext.Entry(emp01).State);//Detached
                //Console.WriteLine(companyDBContext.Entry(emp02).State);//Detached

                //companyDBContext.ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.TrackAll;//Default Behaviour

                //Employee emp04 = new Employee() { Id = 3, Name = "Omar", Age = 26, Salary = 8_000, Email = "Rana@gmail.com" };

                //companyDBContext.Set<Employee>().Add(emp04); // .toTable instead of dbSet
                // companyDBContext.Employees.Add(emp01); //as Local Sequence 
                // companyDBContext.Add(emp02);
                //companyDBContext.Entry(emp01).State=EntityState.Added;

                #endregion
                #region Get And Update
                //var emp = (from e in companyDBContext.Employees
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //if(emp is not null)
                //{
                //    Console.WriteLine(companyDBContext.Entry(emp).State);
                //    Console.WriteLine(emp.Name);
                //    Console.WriteLine(emp.Email);
                //    emp.Salary = 10_000;
                //    Console.WriteLine(companyDBContext.Entry(emp).State);

                //}
                #endregion

                #region Get And Remove

                //var emp = (from e in companyDBContext.Employees
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //if (emp is not null)
                //{
                //    Console.WriteLine(companyDBContext.Entry(emp).State);
                //    Console.WriteLine(emp.Name);

                //    //companyDBContext.Set<Employee>().Remove(emp); // .toTable instead of dbSet
                //    /*companyDBContext.Employees.Remove(emp); *///as Local Sequence 
                //    companyDBContext.Remove(emp);
                //    //companyDBContext.Entry(emp).State = EntityState.Deleted;
                //    //
                //    Console.WriteLine(companyDBContext.Entry(emp).State);

                //}
                #endregion



            }
            using (var context = new CompanyDBContext())
            {

                //CompanyDBContextSeed.Seed(context);
                //var emp = (from e in context.Employees
                //           where e.Id == 3
                //           select e).FirstOrDefault();

                //var emp = (from e in context.Employees
                //           .Include(e => e.Department)
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //context.Entry(emp).Reference(nameof(Employee.Department)).Load();

                //if (emp is not null)
                //{
                //    Console.WriteLine($"Employee: {emp.Name}, Department: {emp.Department?.Name ?? "No Department"}");
                //}


                //var dept = (from d in context.Departments
                //            .Include(d => d.DepartmentId)
                //            where d.DepartmentId == 1
                //            select d).FirstOrDefault();

                //if (dept is not null)
                //{
                //    Console.WriteLine($"Department: {dept.DepartmentId}, Department Name: {dept?.Name}");

                //    foreach (var instructor in dept.Employees)
                //    {
                //        Console.WriteLine($"Instructor: {instructor.Name}");
                //    }
                //}

                //var res = from d in context.Departments
                //          join e in context.Employees
                //          on d.DepartmentId equals e.DepartmentId
                //          select new
                //          {
                //              EmployeeId = e.Id,
                //              EmployeeName = e.Name,
                //              DepartmentId = d.DepartmentId,
                //              DepartmentName = d.Name,
                //          };

                //res = context.Departments.Join(
                //context.Employees,
                //d => d.DepartmentId,
                //e => e.DepartmentId,
                //(d, e) => new
                //{
                //    EmployeeId = e.Id,
                //    EmployeeName = e.Name,
                //    DepartmentId = d.DepartmentId,
                //    DepartmentName = d.Name,
                //});

                //foreach (var item in res)
                //{
                //    Console.WriteLine($"Employee ID: {item.EmployeeId}, Employee Name: {item.EmployeeName}, Department ID: {item.DepartmentId}, Department Name: {item.DepartmentName}");
                //}


                //var groupJoinRes = context.Departments.GroupJoin(
                //    context.Employees,
                //    d => d.DepartmentId,
                //    e => e.DepartmentId,
                //    (department, employees) => new { department, employees });

                //foreach (var item in groupJoinRes)
                //{
                //    Console.WriteLine($"Department: {item.department.DepartmentId}, {item.department.Name}");
                //    foreach (var employee in item.employees)
                //    {
                //        Console.WriteLine($" ---Employee: {employee.Id}, {employee.Name}");
                //    }
                //}


                var groupJoinRes02 = context.Departments.GroupJoin(
                    context.Employees,
                    d => d.DepartmentId,
                    e => e.DepartmentId,
                    (department, employees) => new
                    { department
                      ,employees = employees.DefaultIfEmpty()
                    }
                    ).SelectMany(gColl => gColl.employees, (gColl, emp) => new 
                    { 
                        d = gColl.department
                        , emp 
                    });

                foreach (var item in groupJoinRes02)
                {
                    Console.WriteLine($"{item.d.Name} : {item.emp?.Name ?? "No Emp"}");
                }

                groupJoinRes02 = from d in context.Departments
                                 join e in context.Employees
                                 on d.DepartmentId equals e.DepartmentId into employees
                                 from emp in employees.DefaultIfEmpty()
                                 select new
                                 {
                                     d
                                    ,
                                     emp
                                 };

                foreach (var item in groupJoinRes02)
                {
                    Console.WriteLine($"{item.d.Name} : {item.emp?.Name ?? "No Emp"}");
                }


                var crossJoin = from d in context.Departments
                                from e in context.Employees
                                select new
                                {
                                    e,
                                    d
                                };

                foreach (var item in crossJoin)
                {
                    Console.WriteLine($"{item.e.Name} : {item.d.Name}");
                }


                var result = context.EmployeeDepartmentsView;

                foreach (var item in result)
                {
                    Console.WriteLine($"Employee ID: {item.EmployeeId}, Employee Name: {item.EmployeeName}, Department ID: {item.Departmentid}, Department Name: {item.DepartmentName}");
                }

            }

        }
    }
}
