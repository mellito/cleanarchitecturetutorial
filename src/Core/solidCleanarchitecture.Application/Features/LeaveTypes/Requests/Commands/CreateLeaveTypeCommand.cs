using MediatR;
using solidCleanarchitecture.Application.Dtos.LeaveType;
using solidCleanarchitecture.Application.Responses;
namespace solidCleanarchitecture.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
    }
}