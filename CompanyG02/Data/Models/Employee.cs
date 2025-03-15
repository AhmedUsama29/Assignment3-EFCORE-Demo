using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.Data.Models
{
    //Mapping Ways
    //1)By Convention : Default Behaviour of efcore
    //2)Data Annotation
    //3)Fluent Apis
    //4)Configuration Classes  : Enhancement Fluent Apis
    //internal class Employee//POCO Class 
    //{   //Id EmployeeId
    //    public int Id { get; set; }
    //    #region Main Properties
    //    public required string Name { get; set; }
    //    public int? Age { get; set; }
    //    public double Salary { get; set; }
    //    public string? Password { get; set; }
    //    public string? Email { get; set; }
    //    #endregion



    //}

    internal class Employee//POCO Class 
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 10)]
        public required string Name { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public double Salary { get; set; }

        public int? Age { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }


        #region One To Many Relationship (Work)

        //Navigational Property+Id
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        //Navigational Property+Id(Name) In Principle Table
        //public int? DepartmentDepartmentId { get; set; }
        //Navigational Property 
        [InverseProperty(nameof(Models.Department.Employees))]
        public Department? Department { get; set; } //Work Department
        #endregion

        #region One To One Relationship (Manage)

        [InverseProperty(nameof(Models.Department.Manager))]
        public Department? ManagedDepartment { get; set; }

        #endregion

        public Address DetaildAddress { get; set; }

    }
    //create table Employees
    //(
    //id int primary key ,
    //name varchar(20) unique,
    //departmentId int -----
    //)



}
