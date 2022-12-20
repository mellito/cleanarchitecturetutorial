using MediatR;
using solidCleanarchitecture.Application.Dtos.LeaveAllocation;
namespace solidCleanarchitecture.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}