using MediatR;
using solidCleanarchitecture.Application.Dtos.LeaveType;

namespace solidCleanarchitecture.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}