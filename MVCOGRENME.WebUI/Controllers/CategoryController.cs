using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCOGRENME.Business.Abstract;
using MVCOGRENME.Entities.Concrete;
using MVCOGRENME.WebUI.Models;
using MVCOGRENME.Core.Abstract;
using MVCOGRENME.Core.Conrete;

namespace MVCOGRENME.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
            
        public  IActionResult Index()
        {
            ViewBag.title = "Kategoriler";
            var model = new CategoryIndexViewModel
            {
                Categories = _categoryService.GetAll(),
                Category = new Entities.Concrete.Category()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.title = "Kategori Ekle";
            var model = new CategoryAddViewModel
            {
                Category = new Category()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                IReturnException<object> returnException = new ReturnException<object>();
                returnException = this._categoryService.Add(category);
                if (returnException.Status)
                {
                    return Redirect("/Category/Index");
                }
                else
                {
                    return Redirect("/Category/Index?status="+returnException.Status+"&message="+returnException.Message);
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            

            var model = new CategoryUpdateViewModel {
                Category = _categoryService.Get(id)
            };

            ViewBag.title = "Kategori "+model.Category.CategoryName+" Güncelle";

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                IReturnException<object> returnException = new ReturnException<object>();
                returnException = this._categoryService.Update(category);
                
                if (returnException.Status)
                {
                    return Redirect("/Category/Index");
                }
                else
                {
                    return Redirect("/Category/Update/"+category.CategoryID+"/?status="+returnException.Status+"&message="+returnException.Message);
                }

            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            IReturnException<object> returnException = new ReturnException<object>();

            returnException = this._categoryService.Delete(id);
            return Redirect("/Category/Index/?status=" + returnException.Status + "message=" + returnException.Message);
            
        }

        [HttpGet]
        public IActionResult Status(int id)
        {
            _categoryService.Status(id);
            return RedirectToAction("Index");
        }
    }
}
