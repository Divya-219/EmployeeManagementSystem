using EmployeeManagement.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Attendances.Commands.UpdateAttendance;

public  class UpdateAttendanceCommand: IRequest

{
    public int Id { get; set; }

    public DateTime Date{  get; set; }

    public DateTime CheckInTime { get; set; }

    public DateTime CheckOutTime { get; set; }

    public AttendanceStatus Status { get; set; }


}
