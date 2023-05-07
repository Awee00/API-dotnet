using API.Context;
using API.Handlers;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;

namespace API.Repositories.Data;

public class AccountRepository : GeneralRepository<Account, string, MyContext>, IAccountRepository
{
    public AccountRepository(MyContext context) : base(context) { }

    public int Register(RegisterVM registerVM)
    {
        int result = 0;
        // University Table
        var university = new University
        {
            Name = registerVM.UniversityName
        };
        _context.Set<University>().Add(university);
        result = _context.SaveChanges();

        // Education Table
        var education = new Education
        {
            Major = registerVM.Major,
            Degree = registerVM.Degree,
            GPA = registerVM.GPA,
            UniversityId = university.Id
        };
        _context.Set<Education>().Add(education);
        result += _context.SaveChanges();

        // Employee Table
        var employee = new Employee
        {
            NIK = registerVM.NIK,
            FirstName = registerVM.FirstName,
            LastName = registerVM.LastName,
            Gender = registerVM.Gender,
            BirthDate = registerVM.BirthDate,
            Email = registerVM.Email,
            HiringDate = DateTime.Now,
            PhoneNumber = registerVM.PhoneNumber
        };
        _context.Set<Employee>().Add(employee);
        result += _context.SaveChanges();

        // Account Table
        var account = new Account
        {
            EmployeeNIK = registerVM.NIK,
            Password = Hashing.HashPassword(registerVM.Password)
        };
        _context.Set<Account>().Add(account);
        result += _context.SaveChanges();

        // Profiling Table
        var profiling = new Profiling
        {
            EmployeeNIK = registerVM.NIK,
            EducationId = education.Id
        };
        _context.Set<Profiling>().Add(profiling);
        result += _context.SaveChanges();

        // AccountRole Table
        var accountRole = new AccountRole
        {
            AccountNIK = registerVM.NIK,
            RoleId = 1 // user
        };
        _context.Set<AccountRole>().Add(accountRole);
        result += _context.SaveChanges();

        return result;
    }

    public bool Login(LoginVM loginVM)
    {
        // ambil data dari database berdasarkan email di tabel employee
        // gabungkan dari data tabel employee dengan tabel account berdasarkan NIK
        // cocokan data tersebut dengan password yang diinputkan
        // cek apakah data falid atau tidak

        var getEmployeeAccount = _context.Employees.Join(_context.Accounts,
            e => e.NIK,
            a => a.EmployeeNIK,
            (e, a) => new
            {
                Email = e.Email,
                Password = a.Password
            }).FirstOrDefault(e => e.Email == loginVM.Email);
        if (getEmployeeAccount == null)
        {
            return false;
        }

        return Hashing.ValidatePassword(loginVM.Password, getEmployeeAccount.Password);
    }
}
