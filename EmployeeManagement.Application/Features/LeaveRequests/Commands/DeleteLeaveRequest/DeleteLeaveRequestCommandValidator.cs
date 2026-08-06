using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EmployeeManagement.Application.Features.LeaveRequests.Commands.DeleteLeaveRequest
{
    public  class DeleteLeaveRequestCommandValidator:AbstractValidator<DeleteLeaveRequestCommand>
    {
        public DeleteLeaveRequestCommandValidator() {
            RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Valid leaverequest Id is required.");
        }
    }
}
