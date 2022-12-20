using FluentValidation;
using solidCleanarchitecture.Application.Contracts.Persistence;

namespace solidCleanarchitecture.Application.Dtos.LeaveAllocation.Validator
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _ileaveTypeRepository;

        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository ileaveTypeRepository)
        {
            _ileaveTypeRepository = ileaveTypeRepository;
            Include(new ILeaveAllocationDtoValidator(_ileaveTypeRepository));
        }

    }
}