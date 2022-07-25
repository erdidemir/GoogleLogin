using Google.Apis.Auth;
using GoogleLogin.Contexts;
using GoogleLogin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoogleLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyContext _context;

        public LoginController()
        {
            _context = new MyContext();
        }

        [HttpPost]
        public IActionResult GoogleLogin(GoogleLoginModel googleLoginModel)
        {
            var payload = GoogleJsonWebSignature.ValidateAsync(googleLoginModel.TokenId, new GoogleJsonWebSignature.ValidationSettings()).Result;

            if (payload is null)
                return BadRequest("Kullanıcı bulunamadı!");

            var userInDB = _context.Users.FirstOrDefault(x => x.Email == payload.Email);

            if (userInDB is null)
            {
                _context.Users.Add(new User { Email = payload.Email, FirstName = payload.GivenName, LastName = payload.FamilyName });
                _context.SaveChanges();
            }

            //Login işlemleri

            return Ok();


        }
    }
}
