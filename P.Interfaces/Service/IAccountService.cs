using DTO;

namespace P.Interfaces
{
    public interface IAccountService : IRequestResponse
    {
        Task<AutorizationDTO> Login(LoginDTO dto);
    }
}
