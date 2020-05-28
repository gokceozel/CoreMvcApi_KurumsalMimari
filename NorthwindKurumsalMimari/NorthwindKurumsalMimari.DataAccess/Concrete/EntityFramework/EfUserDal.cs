using NorthwindKurumsalMimari.Core.DataAccess.EntityFramework;
using NorthwindKurumsalMimari.DataAccess.Abstarct;
using NorthwindKurumsalMimari.DataAccess.Concrete.EntityFramework.Contexts;
using NorthwindKurumsalMimari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NorthwindKurumsalMimari.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new NorthwindContext())
            {
                var result = (from operationClaim in context.OperationClaims
                              join userOperation in context.UserOperationClaims
                              on operationClaim.Id equals userOperation.Id
                              where userOperation.UserId == user.Id
                              select new OperationClaim
                              {
                                  Id = operationClaim.Id,
                                  Name = operationClaim.Name
                              });

                return result.ToList();
            }
        }
    }
}
