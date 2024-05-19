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

        public async Task<IActionResult> Index()
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
        public async Task<IActionResult> UsuarioForm([FromRoute] string guid)
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

        [HttpPost]
        public IActionResult EditUsuario(UsuarioCreateDTO user)
        {
            if (user.Guid != null)
            {
                // Actualizamos usuario
                TempData["SuccessMessage"] = "Usuario actualizado exitosamente";
                return Redirect("/Usuario");
            }
            else
            {
                // Creamos un usuario nuevo
                TempData["SuccessMessage"] = "Usuario creado exitosamente";
                return Redirect("/Usuario");
            }
        }


        [HttpDelete("DeleteUser/{guid}")]
        public async Task<IActionResult> DeleteUser(string guid)
        {
            try
            {
                return Json(new { message = "Usuario eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }
    }
}
