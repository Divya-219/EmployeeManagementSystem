using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;
public class UpdateDepartmentCommand:IRequest<int>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
