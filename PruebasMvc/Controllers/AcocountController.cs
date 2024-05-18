using Microsoft.AspNetCore.Mvc;
using P.Interfaces;

namespace PruebasMvc.Controllers
{
    public class AcocountController : Controller
    {
        private readonly IApiAccountController _apiAccountService;

        public AcocountController(IApiAccountController apiAccountService)
        {
            _apiAccountService = apiAccountService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
