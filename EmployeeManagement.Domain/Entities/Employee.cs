using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee:BaseEntity
    {
        
        public string FirstName { get; private set; } = string.Empty;
        public string LastName {  get; private set; } = string.Empty;

        public string Email {  get; private set; } = string.Empty;

        public string PhoneNumber {  get; private set; }  = string.Empty;

        public DateTime HireDate { get; private set; }

        public decimal Salary { get; private set; }

        public EmployeeStatus Status { get; private set; }



        public int DepartmentId {  get; private set; }

        public int RoleId {  get; private set; }

        public Department Department { get; private set; } = null!;


        public Role Role { get; private set; } = null!;

        public ICollection<Attendance> Attendances {  get;private set; }=new List<Attendance>();

        public ICollection <LeaveRequest> LeavesRequests { get; private set; }=new List<LeaveRequest>();


        public Employee(string firstName, String lastName, string email, String phoneNumber, DateTime hireDate, Decimal salary, int departmentid, int roleid)
        {
            //Rule 1: First Name is required

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("FirstNmae is requird");


            }
            //Rule 2: Last Name is required

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("LastNmae is requird");


            }
            //Rule 3: Email is required

             
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required.");
                  
            }
        

            //Rule 4: Salary cannot be negative

            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative.");
            }

            //Rule 5: Hire date cannot be in the future
            if (hireDate > DateTime.Today)
            {
                throw new ArgumentException("Hire date cannot be in the future.");
            }


            FirstName = firstName;
            LastName=lastName;
            Email=email;
            PhoneNumber=phoneNumber;
            HireDate=hireDate;
            Salary=salary;
            DepartmentId=departmentid;
            RoleId=roleid;
            Status = EmployeeStatus.Active;
        }


        // Business Method
        public void UpdateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");

            Email = email;
        }
        public void UpdatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number is required.");

            PhoneNumber = phoneNumber;
        }
        public void UpdateSalary(decimal salary)
        {
            if (salary < 0)
                throw new ArgumentException("Salary cannot be negative.");

            Salary = salary;
        }
        public void ChangeDepartment(int departmentId)
        {
            if (departmentId <= 0)
                throw new ArgumentException("Invalid department.");

            DepartmentId = departmentId;
        }
        public void ChangeRole(int roleId)
        {
            if (roleId <= 0)
                throw new ArgumentException("Invalid role.");

            RoleId = roleId;
        }
        public void ChangeStatus(EmployeeStatus status)
        {
            Status = status;
        }

        public void UpdateName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.");

            FirstName = firstName;
            LastName = lastName;
        }


    }
}
