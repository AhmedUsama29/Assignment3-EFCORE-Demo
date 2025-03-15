using CompanyG02.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CompanyG02.Data
{
    internal class CompanyDBContext : DbContext //Base Class For Every Context 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=. ;Initial Catalog=Company ;Integrated Security =True");//old syntax
            optionsBuilder.UseSqlServer("Server=IIZEEX;Database=Company;Trusted_Connection=True;TrustServerCertificate=True;");//new syntax
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Work Relationship
            modelBuilder.Entity<Department>()//pk
                        .HasMany(d => d.Employees)
                        .WithOne(e=>e.Department)
                        .HasForeignKey(e=>e.DepartmentId)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Employee>()
            //            .HasOne(e => e.Department)
            //            .WithMany(d=>d.Employees)
            //            .HasForeignKey(e => e.DepartmentId)
            //            .IsRequired(false)
            //            .OnDelete(DeleteBehavior.Cascade);

            //One To One 
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ManagedDepartment)
                .WithOne(d => d.Manager)
                .HasForeignKey<Department>(d => d.ManagerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Project> Projects { get; set; }

    }
}
