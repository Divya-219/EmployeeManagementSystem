using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler:IRequestHandler<CreateRoleCommand,int>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {  _roleRepository = roleRepository; 
    }
    public async Task <int>Handle(CreateRoleCommand command,CancellationToken cancellationToken)
    {
        var role = new Role(command.Name,command.Description);
        await _roleRepository.AddAsync(role);
        return role.Id;

    }
}

