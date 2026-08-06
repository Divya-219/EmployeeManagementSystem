using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Attendances.Commands.DeleteAttendance
{
    public class DeleteAttendanceCommandValidator: AbstractValidator<DeleteAttendanceCommand>
    {
        public DeleteAttendanceCommandValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
