using solidCleanarchitecture.Application.Dtos.Common;

namespace solidCleanarchitecture.Application.Dtos.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto : BaseDto
    {
        public bool? Approved { get; set; }
    }
}