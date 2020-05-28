using Autofac;
using NorthwindKurumsalMimari.Business.Abstract;
using NorthwindKurumsalMimari.Business.Concrete;
using NorthwindKurumsalMimari.DataAccess.Abstarct;
using NorthwindKurumsalMimari.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
        }
    }
}
