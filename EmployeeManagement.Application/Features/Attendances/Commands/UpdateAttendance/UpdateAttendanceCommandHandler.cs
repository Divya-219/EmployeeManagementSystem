using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagement.Application.Features.Attendances.Commands.UpdateAttendance;

public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand>
{
    private readonly IAttendanceRepository _attendanceRepository;

    public UpdateAttendanceCommandHandler(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;

    }

    public async Task Handle(UpdateAttendanceCommand command, CancellationToken cancellationToken)
    {
        var attendance = await _attendanceRepository.GetByIdAsync(command.Id);
        if (attendance == null)
            throw new Exception("Attendance not found.");

        attendance.UpdateAttendance(
            command.Date,
            command.CheckInTime,
            command.CheckOutTime,
            command.Status);

        await _attendanceRepository.UpdateAsync(attendance);

    }

}
