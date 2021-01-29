using BC.Ns.Data.EFCore.Entities;
using BC.WebApi.Logger;
using Microsoft.Azure;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BC.Ns.Data.EFCore
{
    public class NsDbContext : DbContext
    {
        private readonly ILogger<NsDbContext> _logger;

        public NsDbContext(ILogger<NsDbContext> logger)
        {
            _logger = logger;
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlServer = ConfigurationManager.ConnectionStrings["mssqllocaldb"].ConnectionString;
            optionsBuilder.UseSqlServer(sqlServer);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            base.OnModelCreating(modelBuilder);
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                //entity.SetTableName(entity.TranslateMemberName(entity.GetTableName()));
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
