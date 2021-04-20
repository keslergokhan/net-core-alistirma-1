using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Business.Abstract;
using MVCOGRENME.Core.Abstract;
using MVCOGRENME.DataAccess.Abstract;
using MVCOGRENME.Entities.Concrete;

namespace MVCOGRENME.Business.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            this._userDal = userDal;
        }
        public IReturnException<object> Add(User user)
        {
            IReturnException<object> returnException = new MVCOGRENME.Core.Conrete.ReturnException<object>();
            try
            {
                int control = _userDal.Add(user);

                if (control > 0)
                {
                    returnException.SetReturnException(true, "Ürün başarıyla eklendi !",user);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(true, "Ürün ekleme işleminde bir problem oluştu !", user);
                    return returnException;
                }
            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status: false, Message: "Teknik bir sıkıntı oluştu !", Data: user, Exception: e);
                return returnException;
            }
        }
        public User Get(int UserID)
        {
            return _userDal.Get(u => u.UserID == UserID);
        }
        public List<User> GetAll()
        {
            return _userDal.GetList();
        }
        public IReturnException<object> Remove(User user)
        {
            IReturnException<object> returnException = new MVCOGRENME.Core.Conrete.ReturnException<object>();

            try
            {
                int control = _userDal.Delete(user);
                if (control > 0)
                {
                    returnException.SetReturnException(true, "Ürün silindi", user);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(false, "Ürün sile işlemi başarısız ",user);
                    return returnException;
                }
            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status: false, Message: "Teknik bir sıkıntı oluştu !", Data: user, Exception: e);
                return returnException;
            }

        }

        public void Status(int UserID)
        {
            User user = _userDal.Get(p => p.UserID == UserID);

            if (user.Status)
            {
                user.Status = false;
                _userDal.Update(user);
            }
            else
            {
                user.Status = true;
                _userDal.Update(user);
            }
        }

        public IReturnException<object> Update(User user)
        {
            IReturnException<object> returnException = new MVCOGRENME.Core.Conrete.ReturnException<object>();
            try
            {
                int control = _userDal.Update(user);
                if (control > 0)
                {
                    returnException.SetReturnException(true, "Ürün güncellendi !",user);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(false, "Ürün güncelleme işlemi başarısız !", user);
                    return returnException;
                }
            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status:false,Message:"Teknik bir sıkıntı oluştu !",Data:user,Exception: e);
                return returnException;
            }
        }
        


    }
}
