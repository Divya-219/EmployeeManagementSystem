using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Departments.Commands.UpdateEmployee;
using EmployeeManagement.Application.Interfaces.Persistence;

namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;

public  class UpdateDepartmentCommandHandler
{
    private readonly IDepartmentRepository _departmentrepository;

    public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository)
    {
        _departmentrepository = departmentRepository;

    }

    public async Task handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = await _departmentrepository.GetByIdAsync(command.Id);
        if (department == null)
        {
            throw new Exception("department not found");

        }

        department.UpdateName(command.Name);
        department.UpdateDescription(command.Description);
        await _departmentrepository.UpdateAsync(department);


    }

}
