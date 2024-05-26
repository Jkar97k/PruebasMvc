using DTO;


namespace P.Interfaces
{
    public interface IApiUserController
    {
        Task<BaseResponse<List<UsuarioDTO>>> GetAllUsers();
        Task<BaseResponse<UsuarioDTO>> GetUserByGuid(string guid);
        Task<BaseResponse<int>> CreateUsuario(UsuarioCreateDTO DTO);
        Task<BaseResponse<int>> PutUsuario(UsuarioDTO DTO);
        Task<BaseResponse<int>> Delete(string guid);
    }
}
