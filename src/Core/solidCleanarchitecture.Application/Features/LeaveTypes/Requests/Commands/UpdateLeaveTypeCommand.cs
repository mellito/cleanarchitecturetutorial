using MediatR;
using solidCleanarchitecture.Application.Dtos.LeaveType;
using solidCleanarchitecture.Application.Responses;
namespace solidCleanarchitecture.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }
    }
}