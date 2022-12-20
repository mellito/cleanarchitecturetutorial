using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using solidCleanarchitecture.Application.Dtos.LeaveRequest;
using MediatR;
namespace solidCleanarchitecture.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}