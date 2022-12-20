using solidCleanarchitecture.Application.Dtos.Common;

namespace solidCleanarchitecture.Application.Dtos.LeaveType
{
    public class LeaveTypeDto : BaseDto, IleaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}