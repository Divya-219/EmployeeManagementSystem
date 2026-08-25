using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EmployeeManagement.Application.Interfaces.Persistence;

namespace EmployeeManagement.Application.Features.Roles.Commands.DeleteRole;

public  class DeleteRoleCommandHandler:IRequestHandler<DeleteRoleCommand,int>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<int> Handle(DeleteRoleCommand command,CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(command.Id);
        if (role == null)
        {

            throw new Exception($"Role with ID {command.Id} was not found.");
        }
        await _roleRepository.DeleteAsync(role);
        return command.Id;
    }



}
