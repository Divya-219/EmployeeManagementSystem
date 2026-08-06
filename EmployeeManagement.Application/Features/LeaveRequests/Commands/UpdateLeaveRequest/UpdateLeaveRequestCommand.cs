using MediatR;
using EmployeeManagement.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }

        public DateTime StartDate {  get; set; }

        public DateTime EndDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public LeaveType LeaveType { get; set; }

        public LeaveStatus Status { get; set; }



    }
}
