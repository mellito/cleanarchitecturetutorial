using Microsoft.EntityFrameworkCore;
using solidCleanarchitecture.Clean.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace solidCleanarchitecture.Presistence.Configuration.Entities;

public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
{
    public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
    {

    }
}
