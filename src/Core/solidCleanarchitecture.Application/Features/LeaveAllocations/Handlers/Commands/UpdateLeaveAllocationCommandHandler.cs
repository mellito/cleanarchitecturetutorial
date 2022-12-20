using MediatR;
using AutoMapper;
using solidCleanarchitecture.Application.Features.LeaveAllocations.Requests.Commands;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Application.Dtos.LeaveAllocation.Validator;
using solidCleanarchitecture.Application.Exceptions;
using solidCleanarchitecture.Application.Responses;

namespace solidCleanarchitecture.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, BaseCommandResponse>
    {
        private ILeaveTypeRepository _leaveTypeRepository;
        private IleaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public UpdateLeaveAllocationCommandHandler(IleaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.LeaveAllocationDto);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            var leaveAllocation = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
            _mapper.Map(request.LeaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            response.Success = true;
            response.Message = "Update Successfull";
            response.Id = leaveAllocation.Id;
            return response;
        }
    }
}