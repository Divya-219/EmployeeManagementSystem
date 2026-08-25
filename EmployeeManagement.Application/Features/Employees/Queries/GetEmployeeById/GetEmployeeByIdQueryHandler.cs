using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Employees.DTOs;
using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler :IRequestHandler<GetEmployeeByIdQuery,EmployeeDto?>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<EmployeeDto?>Handle(GetEmployeeByIdQuery request,CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByIdWithDetailsAsync(request.Id);
        if (employee == null)
        {
            return null;
        }

        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            HireDate = employee.HireDate,
            Salary = employee.Salary,

            DepartmentName = employee.Department?.Name ?? string.Empty,
            RoleName = employee.Role?.Name ?? string.Empty,
            Status = employee.Status.ToString()
        };

    }

}
