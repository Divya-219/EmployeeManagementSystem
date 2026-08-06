using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EmployeeManagement.Application.Interfaces.Persistence;


namespace EmployeeManagement.Application.Features.LeaveRequests.Commands.DeleteLeaveRequest;

public class DeleteleaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    public DeleteleaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }
    public async Task Handle(DeleteLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        var leaverequest = await _leaveRequestRepository.GetByIdAsync(command.Id);
        if (leaverequest == null)
        {
            throw new Exception("Leave request not found");

        }
        await _leaveRequestRepository.DeleteAsync(leaverequest);

    }
}
