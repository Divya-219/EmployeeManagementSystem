using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EmployeeManagement.Application.Features.Departments.DTOs;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdQuery : IRequest<DepartmentDto>
{
    public int Id { get; set; }
}
