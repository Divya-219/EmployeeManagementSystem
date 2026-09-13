using EmployeeManagement.Application.Features.Roles.DTOs;
using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQueryHandler: IRequestHandler<GetRoleByIdQuery, RoleDto?>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<RoleDto?> Handle( GetRoleByIdQuery query,CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(query.Id);

        if (role == null)
        {
            return null;
        }
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description
        };
    }

}


