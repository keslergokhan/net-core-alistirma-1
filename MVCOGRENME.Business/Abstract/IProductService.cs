using MVCOGRENME.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Core.Abstract;

namespace MVCOGRENME.Business.Abstract
{
    public interface IProductService
    {
        IReturnException<Object> Add(Product product);
        IReturnException<Object> Delete(Product produc);
        IReturnException<Object> Update(Product produc);
        List<Product> GetAll();
        void Status(int ProductID);
        Product Get(int ProductID);
    }
}
