using OnlineCollegeAdmission.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCollegeAdmission.DAL
{
    public class CollegeDBContext : DbContext
    {
        public CollegeDBContext() : base("Online-College-Admission")
        {

        }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
