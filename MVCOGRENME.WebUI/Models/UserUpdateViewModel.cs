using Microsoft.AspNetCore.Http;
using MVCOGRENME.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOGRENME.WebUI.Models
{
    public class UserUpdateViewModel
    {
        public User User { get; set; }
        public IFormFile UserImg { get; set; }
    }
}
