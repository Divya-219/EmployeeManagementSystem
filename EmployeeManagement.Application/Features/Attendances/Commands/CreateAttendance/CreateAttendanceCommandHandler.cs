using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Attendance.Commands.CreateAttendance;

public class CreateAttendanceCommandHandler:IRequestHandler<CreateAttendanceCommand,int>

{
    private readonly IAttendanceRepository _attendanceRepository;

    public CreateAttendanceCommandHandler(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;

    }

    public async Task<int>Handle(CreateAttendanceCommand command, CancellationToken cancellationToken)
    {

     var attendance = new Domain.Entities.Attendance(
    command.Date,
    command.CheckInTime,
    command.CheckOutTime,
    command.EmployeeId,
    AttendanceStatus.Present);

        await _attendanceRepository.AddAsync(attendance);
        return attendance.Id;
          

           


    }
}
