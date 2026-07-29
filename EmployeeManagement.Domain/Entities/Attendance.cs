using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entities
{
    public class Attendance:BaseEntity
    {
        public DateTime Date {  get; set; }

        public DateTime CheckInTime {  get; set; }

        public DateTime CheckOutTime {  get; set; }


        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}
