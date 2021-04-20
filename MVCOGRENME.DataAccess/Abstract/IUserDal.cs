using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Core.Abstract;
using MVCOGRENME.Entities.Concrete;

namespace MVCOGRENME.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
