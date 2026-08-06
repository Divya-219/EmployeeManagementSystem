using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EmployeeManagement.Application.Features.Attendance.Commands.CreateAttendance
{
    public class CreateAttendanceCommand : IRequest<int>
    {
        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public DateTime CheckInTime { get; set; }

        public DateTime CheckOutTime { get; set; }
    }
}
