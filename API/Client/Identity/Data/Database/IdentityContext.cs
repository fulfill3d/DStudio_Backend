using DStudio.Common.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DStudio.API.Client.Identity.Data.Database
{
    public partial class IdentityContext(DbContextOptions<IdentityContext> options) : DbContext(options)
    {
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<App> Apps { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public void RevertAllChangesInTheContext()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}