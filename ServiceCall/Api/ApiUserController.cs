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
        public async Task<BaseResponse<UsuarioDTO>> GetUserByGuid(string guid)
        {
            return await Get<UsuarioDTO>($"Usuario/GetUsuarioByGuid/{guid}");
        }

        public async Task<BaseResponse<int>> CreateUsuario(UsuarioCreateDTO DTO)
        {
            
            var resp = await Post<BaseResponse<int>, UsuarioCreateDTO>("Usuario/CreateUsuario", DTO);
            return resp.Result;
        }

        public async Task<BaseResponse<int>> PutUsuario(UsuarioDTO DTO)
        {

            var resp = await Put<BaseResponse<int>, UsuarioDTO>("Usuario/Put", DTO);
            return resp.Result;
        }
    }
}
