using FluentValidation;

namespace EmployeeManagement.Application.Features.Attendance.Commands.CreateAttendance;

public class CreateAttendanceCommandValidator : AbstractValidator<CreateAttendanceCommand>
{
    public CreateAttendanceCommandValidator()
    {
        RuleFor(x => x.EmployeeId)
            .GreaterThan(0)
            .WithMessage("Valid Employee Id is required.");

        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.Today)
            .WithMessage("Attendance date cannot be in the future.");

        RuleFor(x => x.CheckInTime)
            .NotEmpty()
            .WithMessage("Check-in time is required.");

        RuleFor(x => x.CheckOutTime)
            .NotEmpty()
            .WithMessage("Check-out time is required.");

        RuleFor(x => x)
            .Must(x => x.CheckOutTime > x.CheckInTime)
            .WithMessage("Check-out time must be after check-in time.");
    }
}