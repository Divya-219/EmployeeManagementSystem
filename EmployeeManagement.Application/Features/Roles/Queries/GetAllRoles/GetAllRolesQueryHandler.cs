using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;
using EmployeeManagement.Application.Features.Roles.DTOs;
using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using MediatR;
namespace EmployeeManagement.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesQueryHandler:IRequestHandler<GetAllRolesQuery,List<RoleDto>>
{
    private readonly IRoleRepository _roleRepository;

    public GetAllRolesQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;

    }
    public async Task<List<RoleDto>> Handle(GetAllRolesQuery query, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllAsync();
        return roles.Select(roles => new RoleDto
        {
            Id = roles.Id,
            Name = roles.Name,
            Description = roles.Description,


        }
        ).ToList();
        
    }


}
