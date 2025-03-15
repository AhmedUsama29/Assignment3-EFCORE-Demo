using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.Data.Models
{
    internal class Department
    {

        public int DepartmentId { get; set; }
        public required string Name { get; set; }
        public DateOnly CreationDate { get; set; }




        #region One To Many Relationship (Work)

        [InverseProperty(nameof(Employee.Department))]
        //Navigational Property 
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        #endregion

        #region One To One Relationship (Manage)

        public int? Instructorid { get; set; }


        [ForeignKey("Manager")]


        public int? ManagerId { get; set; }
        [InverseProperty(nameof(Employee.ManagedDepartment))]
        public Employee? Manager { get; set; }
        #endregion
    }
}
