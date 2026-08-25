using EmployeeManagement.Application.Features.Employees.DTOs;
using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesQueryHandler( IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAllEmployeesWithDetailsAsync();

        return employees.Select(employee => new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            Salary = employee.Salary,
            HireDate = employee.HireDate,
            DepartmentName = employee.Department?.Name ?? string.Empty,
            RoleName = employee.Role?.Name ?? string.Empty,
            Status = employee.Status.ToString()

        }).ToList();
    }
}