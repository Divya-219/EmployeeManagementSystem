using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQueryHandler:IRequestHandler<GetRoleByIdQuery, Role?>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;


    }
    public async Task<Role?>Handle(GetRoleByIdQuery query, CancellationToken cancellationToken)
  
         
    {
        var role = await _roleRepository.GetByIdAsync(query.Id);

        return role;
    }

}


