using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entities
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; } = string.Empty;

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

    }
}
