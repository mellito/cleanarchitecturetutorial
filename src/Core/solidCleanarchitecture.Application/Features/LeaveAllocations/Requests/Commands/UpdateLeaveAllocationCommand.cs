using MediatR;
using solidCleanarchitecture.Application.Dtos.LeaveAllocation;
using solidCleanarchitecture.Application.Responses;

namespace solidCleanarchitecture.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}