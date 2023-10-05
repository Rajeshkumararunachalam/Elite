using Elite_HR.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elite_HR.Database
{
    public class EliteHRDbContext :DbContext
    {
        public EliteHRDbContext(DbContextOptions<EliteHRDbContext>options):base(options)
        {

        }
        public DbSet<AdminModel> elite_admin { get; set; }
        public DbSet<EmployeeModel> elite_employee { get; set; }
        public DbSet<EmployerModel> elite_employer { get; set; }
        public DbSet<JobModel> elite_jobs { get; set; }
        public DbSet<JobApplyModel> elite_jobappliers { get; set; }
    }
}
