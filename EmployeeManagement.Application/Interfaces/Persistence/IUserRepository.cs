using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces.Persistence;

public interface IUserRepository :IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
