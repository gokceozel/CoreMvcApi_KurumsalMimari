using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NorthwindKurumsalMimari.Core.Entities.Concrete;
using NorthwindKurumsalMimari.Core.Utilities.Security.Encyption;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using NorthwindKurumsalMimari.Core.Extensions;
using System.Linq;

namespace NorthwindKurumsalMimari.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {

            var securityKey = SecurityKeyHelper.SecurityKey(_tokenOptions.SecurityKey);
            var singinCredentials = SingingCredentialHelper.CreateSingingCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, singinCredentials, operationClaims);
            var jwtSecurityTokenHelper = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHelper.WriteToken(jwt);
            return new AccessToken { 
            Token=token,
            Expiration=_accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                 issuer:tokenOptions.Issuer,
                 audience:tokenOptions.Audience,
                 expires: _accessTokenExpiration,
                 notBefore:DateTime.Now,
                 claims: SetClaims(user,operationClaims),
                 signingCredentials:signingCredentials
                );

            return jwt;

        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claim = new List<Claim>();
            claim.AddNameIdentityfier(user.Id.ToString());
            claim.AddEmail(user.Email);
            claim.AddName($"{user.FirstName}{user.LastName}");
            claim.AddRoles(operationClaims.Select(x=>x.Name).ToArray());
            return claim;
        }
     
    }
}
