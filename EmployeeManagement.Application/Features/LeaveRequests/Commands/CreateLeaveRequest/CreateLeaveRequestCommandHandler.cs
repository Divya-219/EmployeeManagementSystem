using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;
using EmployeeManagement.Application.Features.Attendance.Commands.CreateAttendance;


namespace EmployeeManagement.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler :IRequestHandler<CreateLeaveRequestCommand,int>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<int>Handle(CreateLeaveRequestCommand command, CancellationToken cancellationToken)
    {
        var leaverequest = new LeaveRequest(
            command.StartDate,
            command.EndDate,
            command.Reason,
            command.EmployeeId,
             command.LeaveType
            );
        await _leaveRequestRepository.AddAsync(leaverequest );
        return leaverequest.Id;


    }
}
