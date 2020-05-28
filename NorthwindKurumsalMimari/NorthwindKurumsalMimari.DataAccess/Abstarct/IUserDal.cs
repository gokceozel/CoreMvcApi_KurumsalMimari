using NorthwindKurumsalMimari.Core.DataAccess;
using NorthwindKurumsalMimari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.DataAccess.Abstarct
{
    public  interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
