using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommandValidator:AbstractValidator<CreateRoleCommand>

{
    public CreateRoleCommandValidator() 
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Role is requird")
            .MaximumLength(100)
            .WithMessage("Role name cannot exceed 100 characters. ");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Role description is requird")
            .MaximumLength(250)
            .WithMessage("Role description cannot exceed 250 characters.");
    }
}
