using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
    { 
        _context=context;

    }

    public async Task<User?>GetByEmailAsync(string email)
    {
        return await  _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
