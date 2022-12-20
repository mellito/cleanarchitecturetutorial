using MediatR;
using solidCleanarchitecture.Application.Dtos.LeaveRequest;
using solidCleanarchitecture.Application.Responses;

namespace solidCleanarchitecture.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }
    }
}