using Microsoft.AspNetCore.Mvc;
using P.Interfaces;
using DTO;

namespace PruebasMvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IApiUserController _apiUserController;

        public UsuarioController(IApiUserController apiUserController)
        {
            _apiUserController = apiUserController;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var users = await _apiUserController.GetAllUsers();
                return View(users.Result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }


        [HttpGet("UserForm")]
        [HttpGet("UserForm/{guid}")]
        public async Task<IActionResult> UserForm([FromRoute] string guid)
        {
            try
            {
                if (guid != null)
                {
                    var user = await _apiUserController.GetUserByGuid(guid);

                    if (user.Result == null)
                    {
                        ModelState.AddModelError(string.Empty, "El usuario no existe");
                        return View("Index");
                    }

                    return View(user.Result);
                }

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }
    }
}
