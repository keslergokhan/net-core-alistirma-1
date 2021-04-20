using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace MVCOGRENME.Core.Abstract
{
    public interface IEntityRepository<Entity> where Entity:class,IEntity,new()
    {
        int Add(Entity entity);
        int Update(Entity entity);
        int Delete(Entity entity);
        List<Entity> GetList(Expression<Func<Entity,bool>> filter = null);
        Entity Get(Expression<Func<Entity,bool>> filter = null);
    }
}
