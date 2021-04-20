using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCOGRENME.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOGRENME.WebUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public IFormFile ProductImg { get; set; }
        public List<SelectListItem> Categorys { get; set; }
    }

}
