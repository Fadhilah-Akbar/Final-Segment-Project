using Magang_API.Base;
using Magang_API.Contexts;
using Magang_API.Models;
using Magang_API.Repository.Contracts;

namespace Magang_API.Repository.Data
{
    public class DepartmentRepository : BaseRepository<Department, int, MyContext>, IDepartmentRepository
    {
        public DepartmentRepository(MyContext context) : base(context)
        {
        }
    }
}
