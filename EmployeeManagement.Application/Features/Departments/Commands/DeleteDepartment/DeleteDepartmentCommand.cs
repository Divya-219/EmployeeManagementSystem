using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartment;
public class DeleteDepartmentCommand:IRequest

{
    public int Id {  get; set; }
}
