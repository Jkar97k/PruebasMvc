using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P.Interfaces;

namespace P.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var result = await _accountService.Login(dto);

            if (_accountService.StatusCode != 200)
                return StatusCode(_accountService.StatusCode, _accountService.Message);

            return Ok(new { Result = result, Message = _accountService.Message });
        }
    }
}
