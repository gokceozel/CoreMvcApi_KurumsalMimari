using NorthwindKurumsalMimari.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.Core.Utilities.Security.Jwt
{
    public  interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);

    }
}
