using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Roles.DTOs;
using EmployeeManagement.Application.Interfaces.Persistence;
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
        var role = await _roleRepository.GetAllAsync();
        return role.Select(role => new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,


        }
        ).ToList();
        
    }


}
