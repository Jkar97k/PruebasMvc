using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P.Interfaces;

namespace P.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _usuarioService.GetAllUsers());
        }

        [HttpGet("GetUserByName/{userName}")]
        public async Task<IActionResult> GetUserByName(string userName)
        {
            return Ok(await _usuarioService.GetUserByUserName(userName));
        }

        [HttpGet("GetUserByGuid/{guid}")]
        public async Task<IActionResult> GetUserByGuid(string guid)
        {
            return Ok(await _usuarioService.GetUserByGuid(guid));
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UsuarioCreateDTO dto)
        {
            await _usuarioService.CreateUser(dto);

            if (_usuarioService.StatusCode != 200)
                return StatusCode(_usuarioService.StatusCode, _usuarioService.Message);

            return Ok(new { Message = _usuarioService.Message });
        }
    }
}
