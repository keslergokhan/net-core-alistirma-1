using MVCOGRENME.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOGRENME.Core.Conrete
{
    public class ServiceBase<TIEntityDal,TEntity> : IServiceBase<TEntity>
        where TEntity : class, IEntity, new()
        where TIEntityDal : IEntityRepository<TEntity>
    {

        TIEntityDal _entityDal;
        public ServiceBase(TIEntityDal entityDal)
        {
            this._entityDal = entityDal;
        }

        public IReturnException<object> Add(TEntity entity)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            try
            {
                int control = this._entityDal.Add(entity);
                if (control > 0)
                {
                    returnException.SetReturnException(true, "Başarıyla eklendi !", entity);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(false, "Ekleme işlemi başarısız !", entity);
                    return returnException;
                }
            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status: false, Message: "Teknik bir problem oluştu !", Data: entity, Exception: e);
                return returnException;
            }
        }
        public IReturnException<object> Delete(TEntity entity)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            try
            {
                int control = this._entityDal.Delete(entity);
                if (control > 0)
                {
                    returnException.SetReturnException(true, "Silme işlemi başarılı !", entity);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(false, "Silme işlemi başarısız !", entity);
                    return returnException;
                }

            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status: false, Message: "Teknik bir problem oluştu !", Data: entity, Exception: e);
                return returnException;
            }
        }
        public IReturnException<object> Update(TEntity entity)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            try
            {
                int control = this._entityDal.Update(entity);
                if (control > 0)
                {
                    returnException.SetReturnException(true, "Ekelme işlemi başarılı", entity);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(false, "Ekleme işlemi başarısız", entity);
                    return returnException;
                }
            }
            catch (Exception e)
            {
                returnException.SetReturnException(false, "Teknik bir sıkıntı oluştu !", entity, e);
                return returnException;
            }
        }
        public List<TEntity> GetAll()
        {
            return _entityDal.GetList();
        }

    }
}
