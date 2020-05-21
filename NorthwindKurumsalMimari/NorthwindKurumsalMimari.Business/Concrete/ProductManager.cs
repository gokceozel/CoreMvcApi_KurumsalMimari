using NorthwindKurumsalMimari.Business.Abstract;
using NorthwindKurumsalMimari.Business.Constant;
using NorthwindKurumsalMimari.Core.Utilities.Results;
using NorthwindKurumsalMimari.DataAccess.Abstarct;
using NorthwindKurumsalMimari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindKurumsalMimari.Business.Concrete
{
    public class ProductManager : IProductService
    {

        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            _productDal.Add(product);
          return  new SuccessDataResult<Product>(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessDataResult<Product>(Messages.ProductDeleted);
        }

       public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x=>x.ProductId==productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return  new SuccessDataResult<List<Product>>( _productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessDataResult<Product>( Messages.ProductUpdated);
        }
    }
}
