using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;


public class CreateEmployeeCommandValidator:AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First Name is required.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last Name is required.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Valid email is required.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MinimumLength(10)
            .WithMessage("Phone number must contain at least 10 digits.");

        RuleFor(x => x.Salary)
            .GreaterThan(0)
            .WithMessage("Salary must be greater than zero.");

        RuleFor(x => x.HireDate)
              .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Hire date cannot be in the future.");

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage("Department is required.");

        RuleFor(x => x.RoleId)
            .GreaterThan(0)
            .WithMessage("Role is required.");
    }





}
