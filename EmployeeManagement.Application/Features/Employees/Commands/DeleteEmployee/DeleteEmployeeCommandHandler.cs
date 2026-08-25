using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler: IRequestHandler<DeleteEmployeeCommand,int>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<int> Handle(
       DeleteEmployeeCommand request,
       CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.Id);

        if (employee == null)
        {
            throw new Exception($"Employee with ID {request.Id} not found.");
        }

        await _employeeRepository.DeleteAsync(employee);
        return employee.Id;
    }
}
