using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EmployeeManagement.Application.Features.Roles.Commands.UpdateRole;

public class UpdateRoleCommandValidator:AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Role Id must be grather then 0");

        RuleFor(x=>x.Name).NotEmpty().WithMessage("Name");
        RuleFor(x=>x.Description).NotEmpty().WithMessage("Description");
    }
}
