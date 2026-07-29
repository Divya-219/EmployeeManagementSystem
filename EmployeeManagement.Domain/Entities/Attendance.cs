using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Entities
{
    public class Attendance:BaseEntity
    {
        public DateTime Date {  get; private set; }

        public DateTime CheckInTime {  get; private set; }

        public DateTime CheckOutTime {  get; private set; }

        public AttendanceStatus Status { get; private set; }


        public int EmployeeId { get; private set; }


        public Employee Employee { get; private set; } = null!;


        public Attendance(DateTime date, DateTime checkInTime, DateTime checkOutTime, int employeeId,AttendanceStatus status)
        {
            //EmployeeId must be greater than 0.
            if (employeeId <= 0)
                throw new ArgumentException("Invalid employee.");

            //Check-out time must be after check-in time.

            if (checkOutTime <= checkInTime)
                throw new ArgumentException("Check-out time must be after check-in time.");

            //Date cannot be in the future 
            if (date > DateTime.Today)
            {
                throw new ArgumentException("Hire date cannot be in the future.");
            }





            Date = date;
            CheckInTime=checkInTime; 
            CheckOutTime=checkOutTime;
            EmployeeId=employeeId;
            Status = status;

        }

        // Business Methods
        public void UpdateCheckInTime(DateTime checkInTime)
        {
            if (checkInTime >= CheckOutTime)
                throw new ArgumentException("Check-in time must be before check-out time.");

            CheckInTime = checkInTime;
        }

        public void UpdateCheckOutTime(DateTime checkOutTime)
        {
            if (checkOutTime <= CheckInTime)
                throw new ArgumentException("Check-out time must be after check-in time.");

            CheckOutTime = checkOutTime;
        }

        public void ChangeStatus(AttendanceStatus status)
        {
            Status = status;
        }

        public void UpdateAttendance(
            DateTime date,
            DateTime checkInTime,
            DateTime checkOutTime,
            AttendanceStatus status)
        {
            if (date > DateTime.Today)
                throw new ArgumentException("Attendance date cannot be in the future.");

            if (checkOutTime <= checkInTime)
                throw new ArgumentException("Check-out time must be after check-in time.");

            Date = date;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
            Status = status;
        }
    }
}

