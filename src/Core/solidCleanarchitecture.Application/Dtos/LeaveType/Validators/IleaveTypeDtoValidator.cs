using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace solidCleanarchitecture.Application.Dtos.LeaveType.Validators
{
    public class IleaveTypeDtoValidator : AbstractValidator<IleaveTypeDto>
    {
        public IleaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisionValue} characters");
            RuleFor(p => p.DefaultDays)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0)
            .LessThan(100).WithMessage("{PropertyName} must not exceed {ComparisionValue}");

        }
    }
}