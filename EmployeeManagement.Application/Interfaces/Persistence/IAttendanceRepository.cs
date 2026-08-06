using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Persistence;

public interface IAttendanceRepository
{
    Task<Attendance?> GetByIdAsync(int id);

    Task<IEnumerable<Attendance>> GetAllAsync();

    Task AddAsync(Attendance attendance);

    Task UpdateAsync(Attendance attendance);

    Task DeleteAsync(Attendance attendance);

    Task<bool> ExistsAsync(int id);
}
