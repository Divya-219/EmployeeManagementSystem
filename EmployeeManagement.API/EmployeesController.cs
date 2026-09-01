using EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;
using EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees;
using EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.API;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;


    }
    [Authorize(Roles = "Admin,Manager")]
    [HttpPost]
    public async Task<IActionResult>Create(CreateEmployeeCommand command)
    {
        var employeeId = await _mediator.Send(command);

        return CreatedAtAction(
       nameof(GetById),
       new { id = employeeId },
       new
       {
           Id = employeeId,
           Message = "Employee created successfully."
       });

    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _mediator.Send(
            new GetAllEmployeesQuery());

        return Ok(employees);
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _mediator.Send(
            new GetEmployeeByIdQuery(id));

        if (employee == null)
        {
            return NotFound($"Employee with ID {id} was not found.");
        }

        return Ok(employee);
    }
    [Authorize(Roles = "Admin,Manager")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    int id,
    UpdateEmployeeCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest(
                "Id in URL and request body must match.");
        }

        var updatedId = await _mediator.Send(command);

        return Ok(new
        {
            Id = updatedId,
            Message = "Employee updated successfully."
        });
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteEmployeeCommand
        {
            Id = id
        };

       

        var deletedId = await _mediator.Send(command);

        return Ok(new
        {
            Id = deletedId,
            Message = "Employee deleted successfully."
        });
    }


}
