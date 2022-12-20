using solidCleanarchitecture.Clean.Domain.Common;
namespace solidCleanarchitecture.Clean.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}