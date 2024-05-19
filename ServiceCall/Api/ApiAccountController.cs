using DTO;
using P.Interfaces;

namespace ServiceCall
{
    public class ApiAccountController : HttpBase, IApiAccountController
    {
        public ApiAccountController(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<BaseResponse<AutorizationDTO>> Login(LoginDTO dto)
        {
            var resp = await Post<AutorizationDTO, LoginDTO>("Account/login", dto);
            return resp;
        }
    }
}
