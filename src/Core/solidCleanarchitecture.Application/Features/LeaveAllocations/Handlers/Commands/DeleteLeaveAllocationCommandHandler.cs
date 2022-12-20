using MediatR;
using AutoMapper;
using solidCleanarchitecture.Application.Features.LeaveAllocations.Requests.Commands;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Application.Exceptions;

namespace solidCleanarchitecture.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private IleaveAllocationRepository _leaveAllocationRespository;
        private IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(IleaveAllocationRepository leaveAllocationRespository, IMapper mapper)
        {
            _leaveAllocationRespository = leaveAllocationRespository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRespository.Get(request.Id);
            if (leaveAllocation == null) throw new NotFoundException(nameof(leaveAllocation), request.Id);
            await _leaveAllocationRespository.Delete(leaveAllocation);
            return Unit.Value;
        }
    }
}