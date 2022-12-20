using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using solidCleanarchitecture.Application.Contracts.Persistence;
namespace solidCleanarchitecture.Application.Dtos.LeaveRequest.Validator
{
    public class IleaveRequesDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public IleaveRequesDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.StartDate).LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");
            RuleFor(p => p.EndDate).GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be before {ComparisonValue}");
            RuleFor(p => p.LeaveTypeId).GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                return !leaveTypeExists;
            }).WithMessage("{PropertyName does not exist}");
        }
    }
}