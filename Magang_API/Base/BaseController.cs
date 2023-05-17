using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Magang_API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity,TIRepository,TKey> : ControllerBase
    where TEntity : class
    where TIRepository : IBaseRepository<TEntity,TKey>
    {
        protected readonly TIRepository _repository;

        public BaseController(TIRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var results = await _repository.GetAllAsync();
            if (results == null)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = results
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(TKey id)
        {
            var results = await _repository.GetByIdAsync(id);
            if (results == null)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = results
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(TEntity entity)
        {
            try
            {
                await _repository.InsertAsync(entity);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data insert",
                    }
                });
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status400BadRequest,
                    status = HttpStatusCode.BadRequest.ToString(),
                    data = new
                    {
                        message = "Server Cannot Process Request"
                    }
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(TKey key, TEntity entity)
        {
            if (key.Equals(entity.GetType().GetProperty("Id")) ||
            key.Equals(entity.GetType().GetProperty("Nik")) || key.Equals(entity.GetType().GetProperty("Nim")))
            {
                return BadRequest();
            }

            if (!await _repository.IsExist(key))
            {
                return NotFound();
            }

            try
            {
                await _repository.UpdateAsync(entity);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data update",
                    }
                });
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Server Cannot Process Request"
                    }
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(TKey id)
        {
            if (!await _repository.IsExist(id))
            {
                return NotFound();
            }

            try
            {
                var entity = await _repository.GetByIdAsync(id);
                await _repository.DeleteAsync(entity);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data Sucessfully delete",
                    }
                });
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Server Cannot Process Request"
                    }
                });
            }
        }
    }
}
