using Microsoft.EntityFrameworkCore;
using SpendingTracker.Model.DomainObjects;

namespace SpendingTracker.ServiceLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SystemUser> Users { get; set; }
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<SpendingCategory> Categories { get; set; }
        public DbSet<SpendingGroup> SpendingGroups { get; set; }


        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SystemUser

            modelBuilder.Entity<SystemUser>()
                .ToTable("SystemUser");

            modelBuilder.Entity<SystemUser>()
                .HasIndex(x => x.Login)
                .IsUnique();

            modelBuilder.Entity<SystemUser>()
                .HasMany(x => x.Spendings)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // Если удалять каскадно, то появляется ошибка при связывании категорий и групп
            // сonstraint may cause cycles or multiple cascade paths
            modelBuilder.Entity<SystemUser>()
                .HasMany(x => x.Categories)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region SpendingGroup
            modelBuilder.Entity<SpendingGroup>()
                .ToTable("SpendingGroup")
                .HasIndex(x => new { x.UserID, x.Name });

            modelBuilder.Entity<SpendingGroup>()
                .HasMany(x => x.Spendings)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.GroupID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpendingGroup>()
                .HasMany(x => x.Categories)
                .WithMany(x => x.Spendings);
            #endregion

            #region Spending
            modelBuilder.Entity<Spending>()
                .ToTable("Spending");
            #endregion

            #region category
            modelBuilder.Entity<SpendingCategory>()
                .ToTable("SpendingCategory");
            #endregion
        }
    }
}
