using Microsoft.EntityFrameworkCore;
using solidCleanarchitecture.Clean.Domain;
using solidCleanarchitecture.Clean.Domain.Common;

namespace solidCleanarchitecture.Presistence;

public class solidCleanarchitectureDbContext : DbContext
{
    public solidCleanarchitectureDbContext(DbContextOptions<solidCleanarchitectureDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(solidCleanarchitectureDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
        {
            entry.Entity.ModifiedDate = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveType> LeaveType { get; set; }
}
