using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MVCOGRENME.Entities.Concrete;


namespace MVCOGRENME.WebUI.Models
{
    public class UserAddViewModel
    {
        public User User { get; set; }
        public IFormFile UserImg { get; set; }
    }
}
