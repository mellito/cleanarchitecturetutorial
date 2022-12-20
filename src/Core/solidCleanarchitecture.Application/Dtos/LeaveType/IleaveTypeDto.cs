namespace solidCleanarchitecture.Application.Dtos.LeaveType
{
    public interface IleaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}