using Microsoft.AspNetCore.Mvc;
using P.Interfaces;
using DTO;

namespace PruebasMvc.Controllers
{
    //[Authorize]
    [Route("[controller]")]
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
            var model = new CombinateUserDTO();
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

                    model.usuario = user.Result;
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUsuario(CombinateUserDTO model)
        {
            if (!string.IsNullOrEmpty(model.usuario.Guid))
            {
                // Actualizamos usuario
                TempData["SuccessMessage"] = "Usuario actualizado exitosamente";
                return Redirect("/Usuario");
            }
            else
            {// Creamos un usuario nuevo
                try 
                {
                    if (model.create == null)
                    {
                        model.create = new UsuarioCreateDTO();
                    }

                    if (model.create.Password != model.create.PasswordConfirm)
                    {
                        ModelState.AddModelError(string.Empty, "Las contraseñas no coinciden");
                        model.create.Password = "";
                        model.create.PasswordConfirm = "";
                        return View("UsuarioForm", model.create);
                    }

                    var log = await _apiUserController.CreateUsuario(model.create);

                    TempData["SuccessMessage"] = "Usuario creado exitosamente";
                    return Redirect("/Usuario");

                } catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View();
                    
                }
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
