using Microsoft.EntityFrameworkCore;
using solidCleanarchitecture.Clean.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace solidCleanarchitecture.Presistence.Configuration.Entities;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
         new LeaveType
         {
             Id = 1,
             DefaultDays = 10,
             Name = "Vacation"
         },
           new LeaveType
           {
               Id = 2,
               DefaultDays = 12,
               Name = "Sick"
           }
        );
    }
}
