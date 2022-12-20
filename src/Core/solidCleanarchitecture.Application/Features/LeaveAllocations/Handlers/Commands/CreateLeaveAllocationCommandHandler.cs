using MediatR;
using AutoMapper;
using solidCleanarchitecture.Application.Features.LeaveAllocations.Requests.Commands;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Clean.Domain;
using solidCleanarchitecture.Application.Dtos.LeaveAllocation.Validator;
using solidCleanarchitecture.Application.Responses;

namespace solidCleanarchitecture.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private ILeaveTypeRepository _leaveTypeRespository;
        private IleaveAllocationRepository _leaveAllocationRespository;
        private IMapper _mapper;
        public CreateLeaveAllocationCommandHandler(IleaveAllocationRepository leaveAllocationRespository, IMapper mapper, ILeaveTypeRepository leaveTypeRespository)
        {
            _leaveTypeRespository = leaveTypeRespository;
            _leaveAllocationRespository = leaveAllocationRespository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRespository);
            var validatorResult = await validator.ValidateAsync(request.LeaveAllocationDto);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
            leaveAllocation = await _leaveAllocationRespository.Add(leaveAllocation);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = leaveAllocation.Id;
            return response;
        }
    }
}