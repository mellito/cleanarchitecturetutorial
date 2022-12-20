using MediatR;
using solidCleanarchitecture.Application.Dtos.LeaveAllocation;

namespace solidCleanarchitecture.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {

    }
}