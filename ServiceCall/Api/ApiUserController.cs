using DTO;
using P.Interfaces;


namespace ServiceCall
{
    public class ApiUserController : HttpBase, IApiUserController
    {
        public ApiUserController(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<BaseResponse<List<UsuarioDTO>>> GetAllUsers()
        {
            return await Get<List<UsuarioDTO>>("User/GetAll");
        }

    }
}
