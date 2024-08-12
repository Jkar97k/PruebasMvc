using AutoMapper;
using DTO;
using P.Model;
using P.Model.Models;

namespace P.API2.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDTO>().ReverseMap();
            CreateMap<Profesion, ProfesionDTO>().ReverseMap();
        }
    }
}
