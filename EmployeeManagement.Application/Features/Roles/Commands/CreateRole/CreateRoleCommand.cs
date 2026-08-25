using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommand :IRequest<int>
{
    public string Name { get; set; } = string.Empty;


    public string Description { get; set; }= string.Empty;

}
