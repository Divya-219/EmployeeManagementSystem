using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public  class Department

    {
        public int id {  get; set; }

        public string Name { get; set; } = string.Empty;

        public string description { get; set; }=string.Empty;


    }
}
