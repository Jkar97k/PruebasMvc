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


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var users = await _usuarioService.GetAllUsers();
            return Ok(users);  // Devuelve directamente el array de usuarios
        }


        [HttpGet("GetUsuarioByName/{userName}")]
        public async Task<IActionResult> GetUserByName(string userName)
        {
            return Ok(await _usuarioService.GetUserByUserName(userName));
        }

        [HttpGet("GetUsuarioByGuid/{guid}")]
        public async Task<IActionResult> GetUserByGuid(string guid)
        {
            return Ok( await _usuarioService.GetUserByGuid(guid) );
        }

        //[AllowAnonymous]
        [HttpPost("CreateUsuario")]
        public async Task<IActionResult> CreateUser(UsuarioCreateDTO dto)
        {
            await _usuarioService.CreateUser(dto);

            if (_usuarioService.StatusCode != 200)
                return StatusCode(_usuarioService.StatusCode, _usuarioService.Message);

            return Ok(new { Message = "Registro creado Exitosamente" }); /*_usuarioService.Message*/
        }


        [HttpPut("Put")]
        public async Task<ActionResult> Update(UsuarioDTO dto)
        {
            await _usuarioService.Update(dto);

            if (_usuarioService.StatusCode != 200)
                return StatusCode(_usuarioService.StatusCode, _usuarioService.Message);

            return Ok(new { Message = "Registro actualizado" }); /*_usuarioService.Message*/

        }
        [HttpDelete("Delete/{guid}")]
        public async Task<IActionResult> Delete(string guid)
        {
             await _usuarioService.Deletebyguild(guid);

            if (_usuarioService.StatusCode != 200)
                return StatusCode(_usuarioService.StatusCode, _usuarioService.Message);

            return Ok(new { Message = _usuarioService.Message });

        }
    }
}
