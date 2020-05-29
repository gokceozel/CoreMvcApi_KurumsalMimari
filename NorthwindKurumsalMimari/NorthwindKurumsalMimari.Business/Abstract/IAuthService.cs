using NorthwindKurumsalMimari.Core.Entities.Concrete;
using NorthwindKurumsalMimari.Core.Utilities.Results;
using NorthwindKurumsalMimari.Core.Utilities.Security.Jwt;
using NorthwindKurumsalMimari.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
