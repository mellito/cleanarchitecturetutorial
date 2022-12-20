using solidCleanarchitecture.Application.Dtos.LeaveType;
using MediatR;
namespace solidCleanarchitecture.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}