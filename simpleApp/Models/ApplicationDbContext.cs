using Microsoft.EntityFrameworkCore;
using simpleApp.Models.Contracts;

namespace simpleApp.Models
{
    public class ApplicationDbContext : DbContext
    {

        // convention used by Entity Framework 
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // -- create DbSets for all entity types to be managed with EF
        public DbSet<Product> Products { get; set; }


        // On Save Changes
        // -- automation with interfaces example
        // -- handle audit fields (createdOn, createdBy, modifiedBy, modifiedOn) and soft delete fields
        public override int SaveChanges()
        {
            // Auditable fields / soft delete on tables with IAuditableEntity
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList()) 
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "the current user";
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        // intercept delete requests, forward as modified on tables with ISoftDelete
                        if (entry.Entity is ISoftDelete softDelete) 
                        {
                            softDelete.IsDeleted = true;
                            entry.State = EntityState.Modified;
                        }
                        break;
                }
            }

            var result = base.SaveChanges();
            return result;
        }
    }
}
