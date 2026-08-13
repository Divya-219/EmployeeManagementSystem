using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Infrastructure.Persistence.Repositories;

public  class EmployeeRepository : BaseRepository<Employee>,IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context)
       : base(context)
    {
    }
}
