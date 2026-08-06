using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Attendance.DTOs;

public class AttendanceDto
{
    public int Id { get; set; }

    public string EmployeeName { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public DateTime CheckInTime { get; set; }

    public DateTime CheckOutTime { get; set; }
}
