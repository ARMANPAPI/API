using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CityInfo.API.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
       //private readonly IConfiguration _configuration;

       // public AuthenticationController(IConfiguration configuration)
       // {
       //     _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
       // }


       // private CityInfoUserDto ValidateUserCredentials(string? userName
       //   , string? Password)
       // {
       //     return new CityInfoUserDto(1,userName??"","Arman","Papi","Tehran");
       // }



        //[HttpPost("authenticate")]
        //public ActionResult<string> Authenticate(
        //    AuthenticationRequestBody authenticationRequestBody)
        //{
        //    var user= ValidateUserCredentials(authenticationRequestBody.UserName
        //        , authenticationRequestBody.Password);

        //    if (user == null)
        //    {
        //        //دسترسی درست نیست
        //        return Unauthorized();
        //    }

        //    var securetyKey = new SymmetricSecurityKey(
        //        Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])
        //        );

        //    return "";

        //}
    }
}
