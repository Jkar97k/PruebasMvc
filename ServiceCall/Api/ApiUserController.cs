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
            return await Get<List<UsuarioDTO>>("Usuario/GetAll");
        }
        public async Task<BaseResponse<UsuarioCreateDTO>> GetUserByGuid(string guid)
        {
            return await Get<UsuarioCreateDTO>($"Usuario/GetUserByGuid/{guid}");
        }
    }
}
