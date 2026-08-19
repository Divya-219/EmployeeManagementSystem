using EmployeeManagement.Application.Features.Departments.DTOs;
using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;

public class GetAllDepartmentsQueryHandler:IRequestHandler<GetAllDepartmentsQuery,List<DepartmentDto>>
{
    private readonly IDepartmentRepository _departmentsRepository;

    public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentsRepository)
    {
        _departmentsRepository = departmentsRepository;
    }
    public async Task<List<DepartmentDto>> Handle(
       GetAllDepartmentsQuery request,
       CancellationToken cancellationToken)
    {
        var departments = await _departmentsRepository.GetAllAsync();

        return departments.Select(department => new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description
        }).ToList();
    }
}
