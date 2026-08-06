using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler: IRequestHandler<CreateEmployeeCommand, int>

{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int>Handle(CreateEmployeeCommand request,CancellationToken cancellationToken)
    {
        var employee = new Employee(
           request.FirstName,
           request.LastName,
           request.Email,
           request.PhoneNumber,
           request.HireDate,
           request.Salary,
           request.DepartmentId,
           request.RoleId);

        await _employeeRepository.AddAsync(employee);

        return employee.Id;
    }
}
