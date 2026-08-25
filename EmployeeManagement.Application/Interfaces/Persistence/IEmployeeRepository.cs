using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Persistence;


public interface IEmployeeRepository: IBaseRepository<Employee>
{
    
    Task<bool> ExistsAsync(int id);
    Task<Employee?> GetEmployeeByIdWithDetailsAsync(int id);
    Task<List<Employee>> GetAllEmployeesWithDetailsAsync();

}
