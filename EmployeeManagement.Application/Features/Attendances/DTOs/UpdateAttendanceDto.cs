using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Attendance.DTOs;

public class UpdateAttendanceDto
{
    public int Id { get; set; }

    public DateTime CheckInTime { get; set; }

    public DateTime CheckOutTime { get; set; }
}
