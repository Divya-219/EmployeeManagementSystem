using EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployee;
using EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;
using EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.API;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;


    }
    [HttpPost]
    public async Task<IActionResult>Create(CreateEmployeeCommand command)
    {
        var employeeId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new {id=employeeId});

    }
 
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
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    int id,
    UpdateEmployeeCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID in URL does not match ID in request.");
        }

        await _mediator.Send(command);

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteEmployeeCommand
        {
            Id = id
        };

        await _mediator.Send(command);

        return NoContent();
    }


}
