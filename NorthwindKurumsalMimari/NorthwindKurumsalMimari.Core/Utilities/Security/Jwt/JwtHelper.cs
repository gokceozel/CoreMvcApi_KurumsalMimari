using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NorthwindKurumsalMimari.Core.Entities.Concrete;
using NorthwindKurumsalMimari.Core.Utilities.Security.Encyption;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {

            var securityKey = SecurityKeyHelper.SecurityKey(_tokenOptions.SecurityKey);
            return new AccessToken();

        }

     
    }
}
