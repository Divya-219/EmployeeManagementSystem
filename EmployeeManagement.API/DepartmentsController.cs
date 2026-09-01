using EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment;
using EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartment;
using EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment;
using EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;
using EmployeeManagement.Application.Features.Departments.Queries.GetDepartmentById;
using EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Authorize(Roles = "Admin,Manager")]
    [HttpPost]
    public async Task<IActionResult> Create( CreateDepartmentCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(Create),
            new { id },
            new { id });
    }
    [Authorize]
    [HttpGet]
    public async Task <IActionResult>GetAll()
    {
        var departments=await _mediator.Send(new GetAllDepartmentsQuery());
        return Ok(departments);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetDepartmentByIdQuery
        {
            Id = id
        };

        var department = await _mediator.Send(query);

        return Ok(department);
    }
    [Authorize(Roles = "Admin,Manager")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id,UpdateDepartmentCommand command)
    {
        if(id !=command.Id )
        {
            return BadRequest("Id in URL and request body must match");

        }
        var updatedId = await _mediator.Send(command);
        return Ok(new
        {
            Id = updatedId,
            Message = "Department updated successfully."
        });
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDepartmentCommand
        {
            Id = id
        };

        var deletedId = await _mediator.Send(command);

        return Ok(new
        {
            Id = deletedId,
            Message = "Department deleted successfully."
        });
    }

}
