using MediatR;
using AutoMapper;
using solidCleanarchitecture.Application.Features.LeaveTypes.Requests.Commands;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Clean.Domain;
using solidCleanarchitecture.Application.Dtos.LeaveType.Validators;
using solidCleanarchitecture.Application.Responses;
namespace solidCleanarchitecture.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private ILeaveTypeRepository _leaveTypeRespository;
        private IMapper _mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRespository, IMapper mapper)
        {
            _leaveTypeRespository = leaveTypeRespository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);

            leaveType = await _leaveTypeRespository.Add(leaveType);

            response.Success = true;
            response.Message = "creation Successfull";
            response.Id = leaveType.Id;
            return response;
        }
    }
}