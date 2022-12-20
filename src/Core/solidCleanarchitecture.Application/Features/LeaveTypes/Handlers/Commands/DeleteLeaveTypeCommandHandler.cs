using MediatR;
using AutoMapper;
using solidCleanarchitecture.Application.Features.LeaveTypes.Requests.Commands;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Application.Exceptions;

namespace solidCleanarchitecture.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private ILeaveTypeRepository _leaveTypeRespository;
        private IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRespository, IMapper mapper)
        {
            _leaveTypeRespository = leaveTypeRespository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRespository.Get(request.Id);
            if (leaveType == null) throw new NotFoundException(nameof(leaveType), request.Id);
            await _leaveTypeRespository.Delete(leaveType);
            return Unit.Value;
        }
    }
}