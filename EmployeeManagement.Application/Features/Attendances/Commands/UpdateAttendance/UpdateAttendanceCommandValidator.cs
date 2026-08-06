using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EmployeeManagement.Application.Features.Attendances.Commands.UpdateAttendance;

public class UpdateAttendanceCommandValidator: AbstractValidator<UpdateAttendanceCommand>
{
    public UpdateAttendanceCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.Today);

        RuleFor(x => x)
            .Must(x => x.CheckOutTime > x.CheckInTime)
            .WithMessage("Check-out time must be after check-in time.");
    }
}
