using EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Roles.DTOs;

namespace EmployeeManagement.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQuery:IRequest<RoleDto?>
{
    public int Id {  get; set; }

    public GetRoleByIdQuery(int id)
    {
        Id = id;
    }
}
