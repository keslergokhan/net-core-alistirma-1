using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Core.Abstract;

namespace MVCOGRENME.Core.Abstract
{
    public interface IServiceBase<TEntity> where TEntity : class,IEntity,new()
    {
        IReturnException<object> Add(TEntity entity);
        IReturnException<object> Delete(TEntity entity);
        IReturnException<object> Update(TEntity entity);
        List<TEntity> GetAll();
    }
}
