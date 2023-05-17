using Magang_API.Base;
using Magang_API.Models;
using Magang_API.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Magang_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController<Role, IRoleRepository, int>

    {
        public RolesController(IRoleRepository repository) : base(repository)
        {
        }
    }
}
