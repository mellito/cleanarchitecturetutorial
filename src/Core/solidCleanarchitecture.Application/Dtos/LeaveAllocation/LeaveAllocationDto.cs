using solidCleanarchitecture.Application.Dtos.Common;
using solidCleanarchitecture.Application.Dtos.LeaveType;

namespace solidCleanarchitecture.Application.Dtos.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}