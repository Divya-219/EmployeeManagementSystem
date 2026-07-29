using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Common;
namespace EmployeeManagement.Domain.Entities
{
    public class Role:BaseEntity
    {
        public string name { get; set; } = string.Empty;
        public string description { get; set; }= string.Empty;
    }
}
