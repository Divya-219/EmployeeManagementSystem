using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommand : IRequest<int>

{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public DateOnly HireDate { get; set; }

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public int RoleId { get; set; }
}
