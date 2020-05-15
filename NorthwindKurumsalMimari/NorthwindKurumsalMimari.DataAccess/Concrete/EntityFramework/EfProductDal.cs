using NorthwindKurumsalMimari.Core.DataAccess.EntityFramework;
using NorthwindKurumsalMimari.DataAccess.Abstarct;
using NorthwindKurumsalMimari.DataAccess.Concrete.EntityFramework.Contexts;
using NorthwindKurumsalMimari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.DataAccess.Concrete.EntityFramework
{
   public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
    }
}
