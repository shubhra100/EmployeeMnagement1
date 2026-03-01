using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Models
{
    public partial class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext()
        {
        }

        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }

        public virtual DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.Username).HasMaxLength(100);
                entity.Property(e => e.PasswordHash).HasMaxLength(500);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");

                entity.Property(e => e.FullName).HasMaxLength(150);
                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.Department).HasMaxLength(100);
                entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Employees)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<LeaveRequest>(entity =>
            {
                entity.ToTable("LeaveRequests");

                entity.Property(e => e.Reason).HasMaxLength(500);
                entity.Property(e => e.Status)
                      .HasMaxLength(50)
                      .HasDefaultValue("Pending");

                entity.Property(e => e.AppliedOn)
                      .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Employee)
                      .WithMany(p => p.LeaveRequests)
                      .HasForeignKey(d => d.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                // 🔥 IMPORTANT FIX (Singular table name)
                entity.ToTable("Attendance");

                entity.HasIndex(e => new { e.EmployeeId, e.AttendanceDate })
                      .IsUnique()
                      .HasDatabaseName("UQ_Attendance");

                entity.HasOne(d => d.Employee)
                      .WithMany(p => p.Attendances)
                      .HasForeignKey(d => d.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}