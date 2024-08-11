using AutoMapper;
using DTO;
using P.Interfaces;
using P.Model;
using P.Model.Models;
using System;


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
            var data = await _usuarioRepository.GetOne(x => x.Username == userName);
            return _mapper.Map<UsuarioCreateDTO>(data);
        }

        public async Task<UsuarioDTO> GetUserByGuid(string guid)
        {
            var data = await _usuarioRepository.GetOne(x => x.Guid == guid);
            return _mapper.Map<UsuarioDTO>(data);
        }

        public async Task CreateUser(UsuarioCreateDTO dto)
        {
            var data = await _usuarioRepository.GetOne(x => x.Username == dto.userName);

            if (data != null)
            {
                this.StatusCode = 400;
                this.Message = "El usuario ya se encuentra registrado, elija otro";
                return;
            }

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.password, salt);

            var user = _mapper.Map<Usuario>(dto);
            user.Password = hashedPassword;
            user.Guid = Guid.NewGuid().ToString();

            this.StatusCode = 200;
            this.Message = "Usuario registrado exitosamente";

            await _usuarioRepository.Add(user);
        }
        public async Task Update(UsuarioDTO dto)
        {
            var dataG = await _usuarioRepository.GetOne(x => x.Guid == dto.guid);


            if (dataG == null)
            {
                this.StatusCode = 400;
                this.Message = "El usuario para actualizar no existe";
                return;
            }
            var dataN = await _usuarioRepository.GetOne(x => x.Username == dto.userName);

            if (dataN != null)
            {
                this.StatusCode = 400;
                this.Message = "El UserName ya esta en uso";
                return;
            }

            var user = _mapper.Map(dto,dataG);
            var result = await _usuarioRepository.Edit(user);

            if (result == 0)
            {
                this.Message = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                this.StatusCode = 500;
                return;
            }

            this.Message = "actualizado exitosamente";
            this.StatusCode = 200;
            return;
        }

        public async Task Deletebyguild(string guid)
        {
           // var data = await _usuarioRepository.GetOne(x => x.Guid == guid );
            var data = await _usuarioRepository.GetOne(x => x.Id == Convert.ToInt32(guid) );

            if (data == null)
            {
                this.StatusCode = 400;
                this.Message = "El usuario no exite, elija otro";
                return;
            }

            //var resp = await _usuarioRepository.DeleteByguid(x => x.Guid == guid);
            var resp = await _usuarioRepository.DeleteByguid(x => x.Id == Convert.ToInt32(guid));

            if (resp == 0) 
            {
                this.Message = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                this.StatusCode = 500;
                return;
            }
            this.Message = "actualizado exitosamente";
            this.StatusCode = 200;
            return;
        }


        //Task<UsuarioDTO> IUsuarioService.GetUserByGuid(string guid)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<UsuarioCreateDTO> IUsuarioService.GetUserByUserName(string name)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
