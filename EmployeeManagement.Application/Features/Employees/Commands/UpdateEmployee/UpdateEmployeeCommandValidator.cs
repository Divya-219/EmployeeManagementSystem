using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandValidator:AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Id)
         .GreaterThan(0)
         .WithMessage("Employee Id must be greater than 0.");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("First Name is required and cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Last Name is required and cannot exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("A valid email address is required.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MaximumLength(15)
            .WithMessage("Phone Number is required and cannot exceed 15 characters.");

        RuleFor(x => x.Salary)
            .GreaterThan(0)
            .WithMessage("Salary must be greater than 0.");

        RuleFor(x => x.HireDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Hire Date cannot be in the future.");

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage("Please select a valid Department.");

        RuleFor(x => x.RoleId)
            .GreaterThan(0)
            .WithMessage("Please select a valid Role.");
    }
}
