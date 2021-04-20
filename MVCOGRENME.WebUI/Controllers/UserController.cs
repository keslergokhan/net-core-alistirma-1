using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCOGRENME.WebUI.Models;
using MVCOGRENME.Entities.Concrete;
using MVCOGRENME.Business.Abstract;
using Microsoft.AspNetCore.Http;
using MVCOGRENME.Core.Abstract;

namespace MVCOGRENME.WebUI.Controllers
{
    public class UserController:Controller
    {
        IUserService _userService;
        IFileService _fileService;

        public UserController(IUserService userService,IFileService fileService)
        {
            this._userService = userService;
            this._fileService = fileService;
        }

        public IActionResult Index()
        {
            var UserIndexViewModel = new UserIndexViewModel
            {
                Users = this._userService.GetAll()
            };

            return View(UserIndexViewModel);
        }


        public IActionResult Add()
        {
            var UserAddViewModel = new UserAddViewModel
            {
                User = new User()
            };

            return View(UserAddViewModel);
        }

        [HttpPost]
        public IActionResult Add(User user,IFormFile UserImg)
        {
            IReturnException<object> returnException = new MVCOGRENME.Core.Conrete.ReturnException<object>();


            if (ModelState.IsValid)
            {
                returnException = _fileService.FileUpload(UserImg, "/wwwroot/images",true,user.UserName);

                if (returnException.Status)//Resim kontrol
                {
                    if (returnException.Data != null) user.UserImg = returnException.Data.ToString();

                    returnException = this._userService.Add(user);

                    if (returnException.Status)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Redirect("/User/Add?status=" + returnException.Status + "&message=" + returnException.Message);
                    }
                }
                else
                {
                    return Redirect("/User/Add?status=" + returnException.Status + "&message=" + returnException.Message);
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
            var userUpdateViewModel = new UserUpdateViewModel
            {
                User = _userService.Get(id)
            };

            return View(userUpdateViewModel);
        }

        [HttpPost]
        public IActionResult Update(User user,IFormFile UserImg=null)
        {
            IReturnException<object> returnException = new MVCOGRENME.Core.Conrete.ReturnException<object>();

            if (ModelState.IsValid)
            {
                if (UserImg != null)//Resim gönderiliyor ise
                {
                    returnException = _fileService.FileUpload(UserImg, "wwwroot/images",true,user.UserName);
                    if (returnException.Status) //Yeni resim yüklendi ise
                    {
                        user.UserImg = returnException.Data.ToString();
                        returnException = _fileService.FileRemove("/wwwroot/images/" + _userService.Get(user.UserID).UserImg, true);
                    }
                }

                returnException = this._userService.Update(user);
                if (returnException.Status)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Redirect("/User/Update/"+user.UserID+"/?status="+returnException.Status+"&message="+returnException.Message);
                }
                
            }

            return View(new UserUpdateViewModel { User = user });

        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            IReturnException<object> returnException = new MVCOGRENME.Core.Conrete.ReturnException<object>();
            
            _fileService.FileRemove("/wwwroot/images/" + _userService.Get(id).UserImg, true);
            returnException = this._userService.Remove(new User { UserID = id });

            if (returnException.Status)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("/User/Index?status="+returnException.Status+"&message="+returnException.Message);
            }
            
        }

        [HttpGet]
        public IActionResult Status(int id)
        {
            _userService.Status(id);
            return RedirectToAction("Index");
        }

    }
}
