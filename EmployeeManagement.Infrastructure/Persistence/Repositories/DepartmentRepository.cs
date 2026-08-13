using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Interfaces.Persistence;


namespace EmployeeManagement.Infrastructure.Persistence.Repositories;

public  class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
