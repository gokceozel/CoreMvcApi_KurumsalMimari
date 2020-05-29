using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.Core.Utilities.Security.Encyption
{
   public class SingingCredentialHelper
    {
        public static SigningCredentials CreateSingingCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,algorithm:SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
