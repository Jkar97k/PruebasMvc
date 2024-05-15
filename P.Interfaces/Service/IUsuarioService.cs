using DTO;

namespace P.Interfaces
{
    public interface IUsuarioService : IRequestResponse
    {
        Task CreateUser(UsuarioCreateDTO dto);
        Task<List<UsuarioDTO>> GetAllUsers();
        Task<UsuarioDTO> GetUserByGuid(string guid);
        Task<UsuarioCreateDTO> GetUserByUserName(string name);
    }
}
