using EmployeeManagement.Application.Interfaces.Authentication;
using EmployeeManagement.Application.Interfaces.Persistence;
using EmployeeManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler:IRequestHandler<RegisterCommand,int>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    public RegisterCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<int> Handle( RegisterCommand request, CancellationToken cancellationToken)
    {
        // Check if email already exists
        var existingUser =await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
        {
            throw new Exception(
                "A user with this email already exists.");
        }

        // Hash password
        var passwordHash =
            _passwordHasher.HashPassword(request.Password);

        // Create user
        var user = new User(
            request.Email,
            passwordHash,
            request.Role);

        // Save user
        await _userRepository.AddAsync(user);

        return user.Id;
    }

}
