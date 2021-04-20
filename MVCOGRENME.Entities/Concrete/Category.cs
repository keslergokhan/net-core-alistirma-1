using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCOGRENME.Entities.Concrete
{
    public class Category : MVCOGRENME.Core.Abstract.IEntity
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "{0} Boş geçmeyin"),StringLength(100,ErrorMessage = "En fazla {1} karakter olmalı !"),Display(Name ="Kategori adı"),Column(TypeName = "varchar")]
        public string CategoryName { get; set; }
        [DefaultValue("false")]
        public bool Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
