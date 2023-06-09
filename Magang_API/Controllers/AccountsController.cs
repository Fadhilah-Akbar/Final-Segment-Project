﻿using Magang_API.Base;
using Magang_API.Handlers;
using Magang_API.Models;
using Magang_API.Repository.Contracts;
using Magang_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Magang_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, IAccountRepository, string>
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AccountsController(IAccountRepository repository,
                                    ITokenService tokenService,
                                    IAccountRoleRepository accountRoleRepository,
                                    IEmployeeRepository employeeRepository)
                                    : base(repository)
        {
            _tokenService = tokenService;
            _accountRoleRepository = accountRoleRepository;
            _employeeRepository = employeeRepository;
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        public async Task<IActionResult> LoginAsync(LoginVM loginVM)
        {
            try
            {
                var result = await _repository.LoginAsync(loginVM);
                if (!result)
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

                var userdata = await _employeeRepository.GetUserDataByEmailAsync(loginVM.Email);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, userdata.Email),
                    new Claim(ClaimTypes.NameIdentifier, userdata.FullName),
                    new Claim("NIK", userdata.Nik)
                };

                var getRoles = await _accountRoleRepository.GetRolesByNikAsync(userdata.Nik);

                foreach (var item in getRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }

                var accessToken = _tokenService.GenerateAccessToken(claims);

                return Ok(new
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Data = accessToken
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new
                                  {
                                      Code = StatusCodes.Status500InternalServerError,
                                      Status = "Internal Server Error",
                                      Errors = new
                                      {
                                          Message = "Invalid Salt Version"
                                      },
                                  });
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterVM registerVM)
        {
            try
            {
                await _repository.RegisterAsync(registerVM);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data Has Successfully Saved",
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
    }
}
