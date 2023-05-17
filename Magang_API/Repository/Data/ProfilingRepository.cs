using Magang_API.Base;
using Magang_API.Contexts;
using Magang_API.Models;
using Magang_API.Repository.Contracts;

namespace Magang_API.Repository.Data
{
    public class ProfilingRepository : BaseRepository<Profiling, string, MyContext>, IProfilingRepository
    {
        public ProfilingRepository(MyContext context) : base(context)
        {
        }
    }
}
