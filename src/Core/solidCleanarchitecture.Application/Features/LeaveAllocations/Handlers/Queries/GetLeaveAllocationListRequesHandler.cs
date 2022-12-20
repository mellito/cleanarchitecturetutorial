using solidCleanarchitecture.Application.Features.LeaveAllocations.Requests.Queries;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Application.Dtos.LeaveAllocation;
using AutoMapper;
using MediatR;

namespace solidCleanarchitecture.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequesHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly IleaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequesHandler(IleaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationListWithDetails();
            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocation);
        }
    }
}