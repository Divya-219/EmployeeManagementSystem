using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeCommand:IRequest
{
    public int Id { get; set; }
}
