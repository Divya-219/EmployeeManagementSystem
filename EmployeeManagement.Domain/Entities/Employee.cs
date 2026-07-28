using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName {  get; set; } = string.Empty;

        public string Email {  get; set; } = string.Empty;

        public string PhoneNumber {  get; set; }  = string.Empty;

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

    }
}
