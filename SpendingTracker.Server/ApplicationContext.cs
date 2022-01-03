using Microsoft.EntityFrameworkCore;
using SpendingTracker.Model;

namespace SpendingTracker.Server
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SystemUser> Users { get; set; }
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<SpendingGroup> SpendingGroups { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            // TODO: Only for test
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spending>()
                .ToTable("Spending")
                .HasOne(x => x.Group)
                .WithMany(x => x.Spendings)
                .HasForeignKey(x => x.GroupKey);

            modelBuilder.Entity<SystemUser>()
                .ToTable("SystemUser")
                .HasIndex(x => x.Login)
                    .IsUnique();

            modelBuilder.Entity<SpendingGroup>()
                .ToTable("SpendingGroup")
                .HasOne(x => x.User)
                .WithMany(x => x.Spendings)
                .HasForeignKey(x => x.UserId);
        }
    }
}
