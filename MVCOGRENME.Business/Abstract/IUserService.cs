using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Entities.Concrete;
using MVCOGRENME.Core.Abstract;

namespace MVCOGRENME.Business.Abstract
{
    public interface IUserService
    {
        IReturnException<Object> Add(User user);
        IReturnException<Object> Remove(User user);
        IReturnException<Object> Update(User user);
        List<User> GetAll();
        User Get(int UserID);
        void Status(int UserID);
    }
}
