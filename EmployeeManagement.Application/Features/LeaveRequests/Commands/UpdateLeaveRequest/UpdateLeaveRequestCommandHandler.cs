using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;

    }

    public async Task Handle(UpdateLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        var leaverequest = await _leaveRequestRepository.GetByIdAsync(command.Id);
        if (leaverequest == null)
        {
            throw new Exception("leve request not found");


        }
        leaverequest.UpdateReason(command.Reason);
        leaverequest.UpdateReason(command.Reason);
        leaverequest.UpdateLeaveDates(command.StartDate, command.EndDate);
        leaverequest.ChangeLeaveType(command.LeaveType);
        leaverequest.ChangeStatus(command.Status);

        await _leaveRequestRepository.UpdateAsync(leaverequest);


    }

}