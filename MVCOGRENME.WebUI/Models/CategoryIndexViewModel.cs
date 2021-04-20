using MVCOGRENME.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOGRENME.WebUI.Models
{
    public class CategoryIndexViewModel
    {
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}
