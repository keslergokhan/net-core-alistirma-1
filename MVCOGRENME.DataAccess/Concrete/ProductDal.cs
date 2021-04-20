using MVCOGRENME.Core.Conrete;
using MVCOGRENME.DataAccess.Abstract;
using MVCOGRENME.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOGRENME.DataAccess.Concrete
{
    public class ProductDal : FEntityRepositoryBase<Product,DbMvcOgrenmeContext>, IProductDal
    {
    }
}
