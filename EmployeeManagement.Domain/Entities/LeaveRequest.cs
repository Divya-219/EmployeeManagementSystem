using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Entities
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate {  get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; } = string.Empty;

        public LeaveType LeaveType { get;  private set; }

        public LeaveStatus Status { get; private set; }

        public int EmployeeId { get; private set; }

        public Employee Employee { get; private set; } = null!;


        public LeaveRequest(DateTime startDate, DateTime endDate, string reason, int employeeId, LeaveType leaveType)
        {


            //Reason cannot be empty.
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Reason is required.");

            //EndDate cannot be before StartDate.
            if (endDate < startDate)
                throw new ArgumentException("End date cannot be before start date.");
            //EmployeeId must be greater than 0.
            if (employeeId <= 0)
                throw new ArgumentException("Invalid employee.");




            StartDate = startDate;
            EndDate= endDate;
            Reason = reason;
            EmployeeId = employeeId;
            LeaveType = leaveType;
            Status = LeaveStatus.Pending;
        }


        // Business Methods
        public void Approve()
        {
            Status = LeaveStatus.Approved;
        }

        public void Reject()
        {
            Status = LeaveStatus.Rejected;
        }

        public void Cancel()
        {
            Status = LeaveStatus.Rejected;
        }

        public void UpdateReason(string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Reason is required.");

            Reason = reason;
        }

        public void UpdateLeaveDates(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException("End date cannot be before start date.");

            StartDate = startDate;
            EndDate = endDate;
        }
        public void ChangeLeaveType(LeaveType leaveType)
        {
            LeaveType = leaveType;
        }

        public void ChangeStatus(LeaveStatus status)
        {
            Status = status;
        }

    }
}
