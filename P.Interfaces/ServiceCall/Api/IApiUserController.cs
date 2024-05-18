using DTO;


namespace P.Interfaces
{
    public interface IApiUserController
    {
        Task<BaseResponse<List<UsuarioDTO>>> GetAllUsers();
        Task<BaseResponse<UsuarioCreateDTO>> GetUserByGuid(string guid);
    }
}
