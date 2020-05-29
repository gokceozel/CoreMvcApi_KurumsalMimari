using NorthwindKurumsalMimari.Business.Abstract;
using NorthwindKurumsalMimari.Business.Constant;
using NorthwindKurumsalMimari.Core.Entities.Concrete;
using NorthwindKurumsalMimari.Core.Utilities.Results;
using NorthwindKurumsalMimari.Core.Utilities.Security.Hashing;
using NorthwindKurumsalMimari.Core.Utilities.Security.Jwt;
using NorthwindKurumsalMimari.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
     
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
       
            if (userToCheck==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck,Messages.SuccessLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(message: Messages.AlreadyExists);
            }
            return new SuccessResult();
        }
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt,
                Status=true
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.RegisterSuccess);
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated); 
        }



    }
}
