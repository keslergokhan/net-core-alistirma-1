using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCOGRENME.Business.Abstract;
using MVCOGRENME.Core.Abstract;
using MVCOGRENME.Entities.Concrete;
using MVCOGRENME.WebUI.Models;

namespace MVCOGRENME.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        IFileService _fileService;
        public ProductController(IProductService productService,IFileService fileService,ICategoryService categoryService)
        {
            this._productService = productService;
            this._fileService = fileService;
            this._categoryService = categoryService;
        }

       public IActionResult Index()
        {
            ViewBag.title = "Ürünler";
            var model = new ProductIndexViewModel
            {
                Product = new Entities.Concrete.Product(),
                Products = _productService.GetAll(),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.title = "Ürün ekle";
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categorys = _categoryService.CategorySelectListGet()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Product product, IFormFile ProductImg)
        {
            if (ModelState.IsValid)
            {
                IReturnException<object> returnException = new MVCOGRENME.Core.Conrete.ReturnException<object>();
                returnException = this._fileService.FileUpload(ProductImg, "/wwwroot/images/Product/",true,product.ProductName);

                if (returnException.Status)
                {
                    if (returnException.Data != null) product.ProductImg = returnException.Data.ToString();

                    returnException = this._productService.Add(product);
                    if (returnException.Status)
                    {
                        return Redirect("/Product/Index/?status="+returnException.Status+"&message="+returnException.Message);
                    }
                    else
                    {
                        return Redirect("/Product/Add/?status=" + returnException.Status + "&message=" + returnException.Message);
                    }
                }
                else
                {
                    return Redirect("/Product/Add/?status="+returnException.Status+"&message="+returnException.Message);
                }
            }
            else
            {
                return Redirect("/Product/Add/?message=Lütfen gerekli alanları doldurunuz");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            IReturnException<object> returnException = new MVCOGRENME.Core.Conrete.ReturnException<object>();

            string images = _productService.Get(id).ProductImg;
            returnException = this._productService.Delete(new Product { ProductID = id });

            if (returnException.Status) { 
                _fileService.FileRemove("/wwwroot/images/Product/" + images, true); 
            }

            return Redirect("/Product/Index/?status="+returnException.Status+"&message="+returnException.Message);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.Get(id),
                Categorys = _categoryService.CategorySelectListGet(),
            };

            ViewBag.title = "Ürün "+model.Product.ProductName+" Güncelle";
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Product product,IFormFile ProductImg)
        {
            if (ModelState.IsValid)
            {
                IReturnException<object> returnException = new MVCOGRENME.Core.Conrete.ReturnException<object>();

                if (ProductImg != null)//Resim gönderiliyor ise
                {
                    returnException = _fileService.FileUpload(ProductImg, "/wwwroot/images/Product/", true, product.ProductName);
                    if (returnException.Status) //Yeni resim yüklendi ise
                    {
                        product.ProductImg = returnException.Data.ToString();
                        returnException = _fileService.FileRemove("/wwwroot/images/Product/" + _productService.Get(product.ProductID).ProductImg, true);
                    }
                }

                returnException = _productService.Update(product);

                if (returnException.Status)
                {
                    return Redirect("/Product/Index/?status=1&message=Ürün güncellendi !");
                }
                else
                {
                    return Redirect("/Product/Update/" + product.ProductID + "/?status=0&message=Ürün güncelleme işleminde bir problem oluştu !");
                }
            }
            else
            {
                return Redirect("/Product/Update/" + product.ProductID+"/?status=0&message=Lütfen gerekli alanları doldurunuz !");
            }
        }

        [HttpGet]
        public IActionResult Status(int id)
        {
            _productService.Status(id);
            return RedirectToAction("Index");
        }
    }
}
