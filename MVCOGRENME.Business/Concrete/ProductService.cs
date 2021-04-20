using MVCOGRENME.Business.Abstract;
using MVCOGRENME.Core.Abstract;
using MVCOGRENME.Core.Conrete;
using MVCOGRENME.DataAccess.Abstract;
using MVCOGRENME.DataAccess.Concrete;
using MVCOGRENME.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOGRENME.Business.Concrete
{
    public class ProductService : ServiceBase<IProductDal,Product>,IProductService //En güncel
    {
        IProductDal _productDal;
      
        public ProductService(IProductDal productDal) : base(productDal)
        {
            this._productDal = productDal;
        }

        public Product Get(int ProductID)
        {
            return _productDal.Get(p => p.ProductID == ProductID);
        }

        public void Status(int ProductID)
        {
            Product product = _productDal.Get(p=>p.ProductID == p.ProductID);
            if (product.Status)
            {
                product.Status = false;
                _productDal.Update(product);
            }
            else
            {
                product.Status = true;
                _productDal.Update(product);
            }
        }
    }
}
