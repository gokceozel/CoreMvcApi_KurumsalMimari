using Microsoft.AspNetCore.Mvc;
using NorthwindKurumsalMimari.Business.Abstract;
using NorthwindKurumsalMimari.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindKurumsalMimari.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {

        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(template:"login")]
        public ActionResult Login(UserForLoginDto userForLogin)
        {
          var user= _authService.Login(userForLogin);
          if(!user.Success)
             return BadRequest(user.Message);

          var result=_authService.CreateAccessToken(user.Data);
          if (result.Success)
             return Ok(result.Data);

          return BadRequest(result.Message);

       }

        [HttpPost(template: "register")]
        public ActionResult Register(UserForRegisterDto userForLogin)
        {

           var userExist = _authService.UserExists(userForLogin.Email);
            if (!userExist.Success)
                return BadRequest(userExist.Message);

            var user = _authService.Register(userForLogin, userForLogin.Password);
            var result = _authService.CreateAccessToken(user.Data);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);

        }
    }
}
