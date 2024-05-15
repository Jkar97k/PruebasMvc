using AutoMapper;
using DTO;
using P.Interfaces;
using P.Model;


namespace P.Service
{
    public class UsuarioService : RequestResponse, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> GetAllUsers()
        {
            var data = await _usuarioRepository.Get();
            return _mapper.Map<List<UsuarioDTO>>(data);
        }


        public async Task<UsuarioCreateDTO> GetUserByUserName(string userName)
        {
            var data = await _usuarioRepository.GetOne(x => x.UserName == userName);
            return _mapper.Map<UsuarioCreateDTO>(data);
        }

        public async Task<UsuarioDTO> GetUserByGuid(string guid)
        {
            var data = await _usuarioRepository.GetOne(x => x.Guid == guid);
            return _mapper.Map<UsuarioDTO>(data);
        }

        public async Task CreateUser(UsuarioCreateDTO dto)
        {
            var data = await _usuarioRepository.GetOne(x => x.UserName == dto.UserName);

            if (data != null)
            {
                this.StatusCode = 400;
                this.Message = "El usuario ya se encuentra registrado, elija otro";
                return;
            }

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password, salt);

            var user = _mapper.Map<Usuario>(dto);
            user.Password = hashedPassword;
            user.Guid = Guid.NewGuid().ToString();

            this.StatusCode = 200;
            this.Message = "Usuario registrado exitosamente";

            await _usuarioRepository.Add(user);
        }


        Task<UsuarioDTO> IUsuarioService.GetUserByGuid(string guid)
        {
            throw new NotImplementedException();
        }

        Task<UsuarioCreateDTO> IUsuarioService.GetUserByUserName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
