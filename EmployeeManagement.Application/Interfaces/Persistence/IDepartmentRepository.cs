using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Persistence;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(int id);

    Task<IEnumerable<Department>> GetAllAsync();

    Task AddAsync(Department department);

    Task UpdateAsync(Department department);

    Task DeleteAsync(Department department);

    Task<bool> ExistsAsync(int id);
}
