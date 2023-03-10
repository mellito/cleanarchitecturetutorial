using FluentValidation;
using solidCleanarchitecture.Application.Contracts.Persistence;
namespace solidCleanarchitecture.Application.Dtos.LeaveAllocation.Validator
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} mush be before {ComparisonValue}");
            RuleFor(p => p.Period).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");
            RuleFor(p => p.LeaveTypeId).GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                return !leaveTypeExists;
            }).WithMessage("{PropertyName} does not exist.");

        }
    }
}