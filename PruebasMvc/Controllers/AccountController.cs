using DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using P.Interfaces;

namespace PruebasMvc.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApiAccountController _apiAccountService;

        public AccountController(IHttpContextAccessor httpContextAccessor, IApiAccountController apiAccountService)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiAccountService = apiAccountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            try
            {
                var login = await _apiAccountService.Login(model);
                HttpContext.Session.SetString("token", login.Result.Token);

                var claims = new[] { new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, model.UserName) };
                var identity = new System.Security.Claims.ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new System.Security.Claims.ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return LocalRedirect("/Usuario");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index");
            }
        }
    }
}
