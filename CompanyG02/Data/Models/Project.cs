using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.Data.Models
{
    internal class Project
    {
        [Key]
        public int ProjectNumber { get; set; }
        public required string ProjectName { get; set; }
        public DateOnly CreationDate { get; set; }

    }
}
