using Magang_API.Base;
using Magang_API.Models;
using Magang_API.ViewModels;

namespace Magang_API.Repository.Contracts
{
    public interface IEmployeeRepository : IBaseRepository<Employee,string>
    {
        Task<UserDataVM> GetUserDataByEmailAsync(string email);
    }
}
