using MVCOGRENME.Core.Abstract;
using MVCOGRENME.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOGRENME.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {

    }
}
