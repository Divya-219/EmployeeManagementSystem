using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entities
{
    public  class Department:BaseEntity

    {
      

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; }=string.Empty;

        public ICollection<Employee> Employees { get; private set; } = new List<Employee>();


        public Department(string name, string description)
        {
            //Name cannot be empty.
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Department name is required.");

            //Description cannot be empty.
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Department description is required.");



            Name = name;
            Description=description;
            

        }

        // Business Methods
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Department name is required.");

            Name = name;
        }

        public void UpdateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Department description is required.");

            Description = description;
        }

        public void UpdateDepartment(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Department name is required.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Department description is required.");

            Name = name;
            Description = description;
        }



    }
}
