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

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer' 
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information. 
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
