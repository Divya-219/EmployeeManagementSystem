using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
    {

    }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Attendance> Attendances { get; set; }

    public DbSet<LeaveRequest> LeaveRequests { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        // Configure HireDate as SQL Server 'date'
        modelBuilder.Entity<Employee>()
        .Property(e => e.HireDate)
        .HasColumnType("date");




        // Employee → Department
        modelBuilder.Entity<Employee>()
        .HasOne(e=>e.Department)
        .WithMany(e=>e.Employees)
        .HasForeignKey(e=>e.DepartmentId)
        .OnDelete(DeleteBehavior.Restrict);


        // Employee → Role

        modelBuilder.Entity<Employee>()
        .HasOne(e => e.Role)
        .WithMany(r => r.Employees)
        .HasForeignKey(e => e.RoleId)
        .OnDelete(DeleteBehavior.Restrict);

        
        // Employee → Attendance

        modelBuilder.Entity<Attendance>()
         .HasOne(a => a.Employee)
        .WithMany(e => e.Attendances)
        .HasForeignKey(a => a.EmployeeId)
        .OnDelete(DeleteBehavior.Cascade);

        // Employee → LeaveRequest
        modelBuilder.Entity<LeaveRequest>()
            .HasOne(l => l.Employee)
            .WithMany(e => e.LeavesRequests)
            .HasForeignKey(l => l.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);




    }
}
