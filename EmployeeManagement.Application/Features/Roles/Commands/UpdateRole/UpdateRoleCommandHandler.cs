using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Roles.Commands.UpdateRole;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, int>
{
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;

    }
    public async Task<int> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(command.Id);

        if (role == null)
        {
            throw new Exception($"ROle with id{command.Id} was not found");
        }
        role.UpdateRole(command.Name, command.Description);

        await _roleRepository.UpdateAsync(role);
        return role.Id;
    }
}

