using Microsoft.AspNetCore.Mvc;
using WEB_API.Aplication.Services;

namespace WEB_API.Controllers
{

    [ApiController]        
    [Route("api/v1/login")] 
    public class AuthController : Controller 
    {
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            
            if(username == "vaval" && password == "vaval0645")
            {
                var token = TokenService.GenerateToken(new Domain.Model.Employee());

                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
