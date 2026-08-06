using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest
{
    public  class CreateLeaveRequestCommandValidator :AbstractValidator<CreateLeaveRequestCommand>
    {
        public CreateLeaveRequestCommandValidator() 
        {
            RuleFor(x => x.EmployeeId)
           .GreaterThan(0)
           .WithMessage("Valid Employee Id is required.");

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("Start date must be before or equal to end date.");

            RuleFor(x => x.Reason)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}
