using solidCleanarchitecture.Application.Dtos.LeaveType;
using solidCleanarchitecture.Application.Dtos.Common;
namespace solidCleanarchitecture.Application.Dtos.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DataRequested { get; set; }
        public bool? Approved { get; set; }
    }
}