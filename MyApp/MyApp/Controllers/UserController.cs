using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
 
    public class UserController : Controller
    {
        [HttpGet]
        public string UserName()
        {
            if(!HttpContext.User.Identity.IsAuthenticated)
            {
                HttpContext.Response.StatusCode = 401;
                return "";
            }
            return HttpContext.User.Identity.Name;

        }
    }
}
