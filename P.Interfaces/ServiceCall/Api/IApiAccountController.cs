using DTO;


namespace P.Interfaces
{
    public interface IApiAccountController
    {
        Task<BaseResponse<AutorizationDTO>> Login(LoginDTO dto);
    }
}
