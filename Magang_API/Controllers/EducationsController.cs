using Magang_API.Base;
using Magang_API.Models;
using Magang_API.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Magang_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : BaseController<Education, IEducationRepository, int>

    {
        public EducationsController(IEducationRepository repository) : base(repository)
        {
        }
    }
}
