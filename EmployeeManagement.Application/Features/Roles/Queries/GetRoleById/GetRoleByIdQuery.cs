using EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQuery:IRequest<Role?>
{
    public int Id {  get; set; }

    public GetRoleByIdQuery(int id)
    {
        Id = id;
    }
}
