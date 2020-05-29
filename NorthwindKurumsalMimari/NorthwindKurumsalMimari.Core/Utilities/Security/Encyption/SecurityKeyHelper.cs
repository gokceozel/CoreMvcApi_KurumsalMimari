using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.Core.Utilities.Security.Encyption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey SecurityKey (string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
