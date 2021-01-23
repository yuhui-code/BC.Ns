using BC.Ns.Data.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BC.Ns.Data
{
    public class NsDbContext : DbContext
    {
        public NsDbContext() : base("mssqllocaldb")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 移除EF的表名公约  
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
