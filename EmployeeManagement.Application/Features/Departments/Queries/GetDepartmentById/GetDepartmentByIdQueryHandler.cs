using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Departments.DTOs;
using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetDepartmentById;

public  class GetDepartmentByIdQueryHandler:IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    public async Task<DepartmentDto>Handle(GetDepartmentByIdQuery query,CancellationToken cancellationToken)
    {
        var departments=await _departmentRepository.GetByIdAsync(query.Id);
        if(departments==null)
        {
            throw new Exception($"department with Id {query.Id}was not found");
        }
        return new DepartmentDto
        {
            Id = departments.Id,
            Name = departments.Name,
            Description = departments.Description
        };

    }
}
