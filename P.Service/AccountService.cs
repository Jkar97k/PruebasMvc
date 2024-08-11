using DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using P.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace P.Service
{
    public class AccountService : RequestResponse, IAccountService
    {
        private readonly IUsuarioService _userService;
        private readonly IConfiguration _configuration;


        public AccountService(IUsuarioService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public async Task<AutorizationDTO> Login(LoginDTO dto)
        {
            var user = await _userService.GetUserByUserName(dto.UserName);
            if (user == null)
            {
                this.StatusCode = 400;
                this.Message = "Error en usuario o contraseña";
                return null;
            }

            bool passwordsMatch = BCrypt.Net.BCrypt.Verify(dto.Password, user?.password);
            if (!passwordsMatch)
            {
                this.StatusCode = 400;
                this.Message = "Error en usuario o contraseña";
                return null;
            }

            this.StatusCode = 200;

            return GenerateToken(user);
        }


        private AutorizationDTO GenerateToken(UsuarioCreateDTO dto)
        {
            var secret = _configuration["jwt"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresSuper = DateTime.UtcNow.AddMinutes(60); // Tiempo de expiracion

            var claims = new List<Claim>
            {
                new Claim("Name", dto.name),
                new Claim("UserName", dto.userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var jwtToken = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiresSuper,
               signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            AutorizationDTO autorizacion = new AutorizationDTO();
            autorizacion.Token = token;
            autorizacion.Expiration = expiresSuper;

            return autorizacion;
        }
    }
}
