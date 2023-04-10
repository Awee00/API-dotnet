using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Profiling> Profilings { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Role> Roles { get; set; }

    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One to Many Relationship University - Education
        modelBuilder.Entity<University>()
            .HasMany(u => u.Educations)
            .WithOne(e => e.University)
            .HasForeignKey(e => e.UniversityId)
            .OnDelete(DeleteBehavior.Cascade);

        // One to One Relationship Education - Profiling
        modelBuilder.Entity<Education>()
            .HasOne(e => e.Profiling)
            .WithOne(p => p.Education)
            .HasForeignKey<Profiling>(p => p.EducationId)
            .OnDelete(DeleteBehavior.Cascade);

        // One to One Relationship Employee - Profiling
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Profiling)
            .WithOne(p => p.Employee)
            .HasForeignKey<Profiling>(p => p.EmployeeNIK)
            .OnDelete(DeleteBehavior.Cascade);

        // One to One Relationship Employee - Account
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Account)
            .WithOne(a => a.Employee)
            .HasForeignKey<Account>(a => a.EmployeeNIK)
            .OnDelete(DeleteBehavior.Cascade);

        // One to Many Relationship Account - AccountRole
        modelBuilder.Entity<Account>()
            .HasMany(a => a.AccountRoles)
            .WithOne(ar => ar.Account)
            .HasForeignKey(ar => ar.AccountNIK)
            .OnDelete(DeleteBehavior.Cascade);

        // One to Many Relationship Role - AccountRole
        modelBuilder.Entity<Role>()
            .HasMany(r => r.AccountRoles)
            .WithOne(ar => ar.Role)
            .HasForeignKey(ar => ar.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
