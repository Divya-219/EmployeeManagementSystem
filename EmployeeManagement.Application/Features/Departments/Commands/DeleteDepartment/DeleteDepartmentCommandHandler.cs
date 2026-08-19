using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartment;

public class DeleteDepartmentCommandHandler:IRequestHandler<DeleteDepartmentCommand,int>
{
    private readonly IDepartmentRepository _DepartmentRepository;

    public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
    {
        _DepartmentRepository = departmentRepository;

    }

    public async Task<int> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _DepartmentRepository.GetByIdAsync(request.Id);

        if(department == null)
        {
            throw new ArgumentException( $"Department with ID {request.Id}Department not found");
        }
        await _DepartmentRepository.DeleteAsync(department);
        return department.Id;
    }
}
