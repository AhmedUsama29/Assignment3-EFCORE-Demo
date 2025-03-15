using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.Data.Models
{
    //[Owned]
    class Address
    {
        public int? BlockNo { get; set; }

        public string? street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        
    }
}
