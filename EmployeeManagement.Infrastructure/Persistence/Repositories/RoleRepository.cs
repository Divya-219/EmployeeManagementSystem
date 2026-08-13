using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Persistence.Repositories;

public class RoleRepository:BaseRepository<Role>,IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    { }
}
