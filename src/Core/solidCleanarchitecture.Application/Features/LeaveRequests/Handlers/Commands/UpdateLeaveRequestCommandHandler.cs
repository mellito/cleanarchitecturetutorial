using MediatR;
using AutoMapper;
using solidCleanarchitecture.Application.Features.LeaveRequests.Requests.Commands;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Application.Dtos.LeaveRequest.Validator;
using solidCleanarchitecture.Application.Exceptions;
using solidCleanarchitecture.Application.Responses;

namespace solidCleanarchitecture.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, BaseCommandResponse>
    {
        private ILeaveTypeRepository _leaveTypeRepository;
        private ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.LeaveRequestsDto);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if (request.LeaveRequestsDto != null)
            {
                _mapper.Map(request.LeaveRequestsDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);

            }
            response.Success = true;
            response.Message = "Update Successfull";
            response.Id = leaveRequest.Id;
            return response;
        }
    }
}