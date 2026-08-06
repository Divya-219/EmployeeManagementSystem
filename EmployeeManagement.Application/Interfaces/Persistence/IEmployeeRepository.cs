using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Persistence;


public interface IEmployeeRepository
{
    Task<Employee?>GetByIdAsync(int  id);
    Task<IEnumerable<Employee>> GetAllAsync();
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);

    Task DeleteAsync(Employee employee);

    Task<bool> ExistsAsync(int id);

}
