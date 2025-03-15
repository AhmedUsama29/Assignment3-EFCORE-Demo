using DatabaseFirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using NorthwindContext context = new NorthwindContext();

            var count = 4;

            var result = context.Categories.FromSqlRaw($"Select top({0}) * from Categories",count);
            
            var result2 = context.Categories.FromSqlInterpolated($"Select top({count}) * from Categories");

        }
    }
}
