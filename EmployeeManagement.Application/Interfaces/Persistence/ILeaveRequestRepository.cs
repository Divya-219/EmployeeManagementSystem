using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Persistence;


public interface ILeaveRequestRepository
{
    Task<LeaveRequest?> GetByIdAsync(int id);

    Task<IEnumerable<LeaveRequest>> GetAllAsync();

    Task AddAsync(LeaveRequest leaveRequest);

    Task UpdateAsync(LeaveRequest leaveRequest);

    Task DeleteAsync(LeaveRequest leaveRequest);

    Task<bool> ExistsAsync(int id);
}
