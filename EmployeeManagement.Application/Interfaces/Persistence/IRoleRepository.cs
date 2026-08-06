using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Persistence;

public interface IRoleRepository
{
    Task<Role?> GetByIdAsync(int id);

    Task<IEnumerable<Role>> GetAllAsync();

    Task AddAsync(Role role);

    Task UpdateAsync(Role role);

    Task DeleteAsync(Role role);

    Task<bool> ExistsAsync(int id);
}
