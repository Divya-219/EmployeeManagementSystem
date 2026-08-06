using EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment
{
    public  class DeleteDepartmentCommandValidator:AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator() 
        {
            RuleFor(x => x.Id)
           .GreaterThan(0)
           .WithMessage("Valid department Id is required.");
        }
    }
}
