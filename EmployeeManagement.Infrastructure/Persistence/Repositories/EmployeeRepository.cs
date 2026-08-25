using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Persistence.Repositories;

public  class EmployeeRepository : BaseRepository<Employee>,IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context)
       : base(context)
    {
    }
    public async Task<Employee?> GetEmployeeByIdWithDetailsAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Role)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
    public async Task<List<Employee>> GetAllEmployeesWithDetailsAsync()
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Role)
            .ToListAsync();
    }
}
