using MediatR;
using AutoMapper;
using solidCleanarchitecture.Application.Features.LeaveTypes.Requests.Commands;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Application.Dtos.LeaveType.Validators;
using solidCleanarchitecture.Application.Responses;
namespace solidCleanarchitecture.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, BaseCommandResponse>
    {
        private ILeaveTypeRepository _leaveTypeRespository;
        private IMapper _mapper;
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRespository, IMapper mapper)
        {
            _leaveTypeRespository = leaveTypeRespository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            var leaveType = await _leaveTypeRespository.Get(request.LeaveTypeDto.Id);
            _mapper.Map(request.LeaveTypeDto, leaveType);
            await _leaveTypeRespository.Update(leaveType);
            response.Success = true;
            response.Message = "Update Successfull";
            response.Id = leaveType.Id;
            return response;
        }
    }
}