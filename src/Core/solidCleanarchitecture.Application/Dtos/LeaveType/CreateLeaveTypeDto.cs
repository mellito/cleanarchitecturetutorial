namespace solidCleanarchitecture.Application.Dtos.LeaveType
{
    public class CreateLeaveTypeDto : IleaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}