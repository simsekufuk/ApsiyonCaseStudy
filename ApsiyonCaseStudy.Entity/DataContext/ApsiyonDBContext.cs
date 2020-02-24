using ApsiyonCaseStudy.Entity.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ApsiyonCaseStudy.Entity.DataContext
{
    public class ApsiyonDBContext : DbContext
    {
        public ApsiyonDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Log> tblLog { get; set; }
    }
}
