using EmployeeManagement.Application.Features.Roles.Commands.CreateRole;
using EmployeeManagement.Application.Features.Roles.Commands.DeleteRole;
using EmployeeManagement.Application.Features.Roles.Commands.UpdateRole;
using EmployeeManagement.Application.Features.Roles.Queries.GetAllRoles;
using EmployeeManagement.Application.Features.Roles.Queries.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(Create),
             new
             {
                 Id = id,
                 Message = "Role created successfully."
             });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());

        return Ok(roles);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var role = await _mediator.Send(
            new GetRoleByIdQuery(id));

        if (role == null)
        {
            return NotFound($"Role with ID {id} was not found.");
        }

        return Ok(role);
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteRoleCommand
        {
            Id = id
        };

        var deletedId = await _mediator.Send(command);

        return Ok(new
        {
            Id = deletedId,
            Message = "Role deleted successfully."
        });
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateRoleCommand command)
    {
        // Check URL ID and body ID
        if (id != command.Id)
        {
            return BadRequest(
                "ID in URL and request body must match.");
        }

        var updatedId = await _mediator.Send(command);

        return Ok(new
        {
            Id = updatedId,
            Message = "Role updated successfully."
        });
    }
}
