using DTO;


namespace P.Interfaces
{
    public interface IApiUserController
    {
        Task<BaseResponse<List<UsuarioDTO>>> GetAllUsers();
    }
}
