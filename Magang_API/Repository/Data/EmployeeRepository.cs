using Magang_API.Base;
using Magang_API.Contexts;
using Magang_API.Models;
using Magang_API.Repository.Contracts;
using Magang_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Magang_API.Repository.Data
{
    public class EmployeeRepository : BaseRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        public EmployeeRepository(MyContext context) : base(context){ }

        public async Task<UserDataVM> GetUserDataByEmailAsync(string email)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            return new UserDataVM
            {
                Nik = employee!.Id,
                Email = employee.Email,
                FullName = string.Concat(employee.FirstName, " ", employee.LastName)
            };
        }
    }
}
