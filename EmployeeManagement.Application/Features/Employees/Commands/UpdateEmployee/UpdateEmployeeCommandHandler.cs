using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(
        IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task Handle(
        UpdateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.Id);

        if (employee == null)
        {
            throw new Exception("Employee not found.");
        }

        employee.UpdateName(request.FirstName, request.LastName);
        employee.UpdateEmail(request.Email);
        employee.UpdatePhoneNumber(request.PhoneNumber);
        employee.UpdateSalary(request.Salary);
        employee.ChangeDepartment(request.DepartmentId);
        employee.ChangeRole(request.RoleId);

        await _employeeRepository.UpdateAsync(employee);
    }
}
