using MVCOGRENME.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Core.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCOGRENME.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        IReturnException<object> Add(Category cate);
        IReturnException<object> Delete(int CategoryID);
        IReturnException<object> Update(Category category);
        Category Get(int CategoryID);
        List<SelectListItem> CategorySelectListGet();
        void Status(int CategoryID);

        
    }
}
