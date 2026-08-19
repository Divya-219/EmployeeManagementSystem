using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;



public class UpdateDepartmentCommandHandler: IRequestHandler<UpdateDepartmentCommand, int>
{
    private readonly IDepartmentRepository _departmentRepository;

    public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<int> Handle(UpdateDepartmentCommand command,CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetByIdAsync(command.Id);

        if (department == null)
        {
            throw new KeyNotFoundException( $"Department with ID {command.Id} was not found.");
        }

        department.UpdateName(command.Name);
        department.UpdateDescription(command.Description);

        await _departmentRepository.UpdateAsync(department);

        return department.Id;
    }
}