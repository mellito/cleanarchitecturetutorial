using solidCleanarchitecture.Application.Features.LeaveRequests.Requests.Queries;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Application.Dtos.LeaveRequest;
using AutoMapper;
using MediatR;
namespace solidCleanarchitecture.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var leaverRequest = await _leaveRequestRepository.GetLeaveRequestListWithDetails();
            return _mapper.Map<List<LeaveRequestListDto>>(leaverRequest);
        }
    }
}