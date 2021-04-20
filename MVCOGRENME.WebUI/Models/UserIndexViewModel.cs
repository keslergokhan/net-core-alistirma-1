using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCOGRENME.Entities.Concrete;

namespace MVCOGRENME.WebUI.Models
{
    public class UserIndexViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
    }
}
