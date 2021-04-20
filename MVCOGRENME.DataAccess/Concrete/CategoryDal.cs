using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Core.Conrete;
using MVCOGRENME.DataAccess.Abstract;
using MVCOGRENME.Entities.Concrete;

namespace MVCOGRENME.DataAccess.Concrete
{
    public class CategoryDal : FEntityRepositoryBase<Category,DbMvcOgrenmeContext>, ICategoryDal
    {
    }
}
