using MVCOGRENME.Core.Abstract;
using MVCOGRENME.DataAccess.Abstract;
using MVCOGRENME.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Core.Abstract;
using MVCOGRENME.Core.Conrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCOGRENME.Business.Concrete
{
    public class CategoryService : MVCOGRENME.Business.Abstract.ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }

        public IReturnException<object> Add(Category category)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            try
            {
                int control = this._categoryDal.Add(category);
                if (control > 0)
                {
                    returnException.SetReturnException(true, "Category başarıyla eklendi !",category);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(false, "Category ekleme işlemi başarısız !",category);
                    return returnException;
                }
            }
            catch(Exception e)
            {
                returnException.SetReturnException(Status:false,Message:"Teknik bir problem oluştu !",Data:category,Exception: e);
                return returnException;
            }
        }

        public List<SelectListItem> CategorySelectListGet()
        {
            return this._categoryDal.GetList().Select(c => new SelectListItem
            {
                Text = c.CategoryName.ToString(),
                Value = c.CategoryID.ToString()
            }).ToList();
        }

        public IReturnException<object> Delete(int CategoryID)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            try
            {
                int control = this._categoryDal.Delete(new Category { CategoryID = CategoryID});
                if (control > 0)
                {
                    returnException.SetReturnException(true, "Category silme işlemi başarılı !",CategoryID);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(false, "Category silme işlemi başarısız !",CategoryID);
                    return returnException;
                }
            
            }
            catch (Exception e)
            {
                returnException.SetReturnException(Status: false, Message: "Teknik bir problem oluştu !", Data: CategoryID, Exception: e);
                return returnException;
            }
        }

        public Category Get(int CategoryID)
        {
            return _categoryDal.Get(c => c.CategoryID == CategoryID);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public void Status(int CategoryID)
        {
            Category category= _categoryDal.Get(p => p.CategoryID == CategoryID);
            if (category.Status)
            {
                category.Status = false;
                _categoryDal.Update(category);
            }
            else
            {
                category.Status = true;
                _categoryDal.Update(category);
            }
        }

        public IReturnException<object> Update(Category category)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            try
            {
                int control = this._categoryDal.Update(category);
                if (control > 0)
                {
                    returnException.SetReturnException(true,"Kategori ekelme işlemi başarılı",category);
                    return returnException;
                }
                else
                {
                    returnException.SetReturnException(false,"Kategori ekleme işlemi başarısız",category);
                    return returnException;
                }
            }
            catch (Exception e)
            {
                returnException.SetReturnException(false,"Teknik bir sıkıntı oluştu !",category,e);
                return returnException;
            }
        }
    }
}
