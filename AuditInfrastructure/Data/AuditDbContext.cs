using AuditDomain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AuditInfrastructure.Data
{
    public class AuditDbContext: DbContext 
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) :
           base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<IsoDirectory> IsoDirectories { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Violation> Violations { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Audit> Audits { get; set; }
        public DbSet<Discrepancy> Discrepancys { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<AuditUser> AuditUsers { get; set; }
        public DbSet<UserViolation> UserViolations { get; set; }
        public DbSet<IsoDiscrepancy> IsoDiscrepancy { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AuditUser>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.AuditUser)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<UserViolation>()
              .HasOne(ua => ua.User)
              .WithMany(u => u.UserViolation)
              .HasForeignKey(ua => ua.UserId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<IsoDiscrepancy>()
             .HasOne(ua => ua.isoDirectory)
             .WithMany(u => u.IsoDiscrepancy)
             .HasForeignKey(ua => ua.IsoDirectoryId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
