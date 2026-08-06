using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Interfaces.Persistence;
using MediatR;

namespace EmployeeManagement.Application.Features.Attendances.Commands.DeleteAttendance;

public class DeleteAttendanceCommandHandler:IRequestHandler<DeleteAttendanceCommand>

{
    private readonly IAttendanceRepository _attendanceRepository;

    public DeleteAttendanceCommandHandler(IAttendanceRepository  attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;

    }
    public async Task Handle(DeleteAttendanceCommand command, CancellationToken cancellationToken)
    {
        var attendance= await _attendanceRepository.GetByIdAsync(command.Id);
        if (attendance == null)
            throw new Exception("Attendance not found");
        await _attendanceRepository.DeleteAsync(attendance);

    }
}
