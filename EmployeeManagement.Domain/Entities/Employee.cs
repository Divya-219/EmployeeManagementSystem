using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee:BaseEntity
    {
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName {  get; set; } = string.Empty;

        public string Email {  get; set; } = string.Empty;

        public string PhoneNumber {  get; set; }  = string.Empty;

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId {  get; set; }

        public int RoleId {  get; set; }

        public Department Department { get; set; } = null!;


        public Role Role { get; set; } = null!;

        public ICollection<Attendance> Attendances {  get; set; }=new List<Attendance>();

        public ICollection <LeaveRequest> LeavesRequests { get; set; }=new List<LeaveRequest>();


    }
}
