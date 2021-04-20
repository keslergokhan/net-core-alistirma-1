using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVCOGRENME.Core.Abstract;

namespace MVCOGRENME.Entities.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Lütfen {0} boş geçmeyin !"),StringLength(100,ErrorMessage = "Lütfen {0} karakteri geçmeyin"),Column(TypeName = "varchar"),Display(Name ="Ürün adı")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Lütfen {0} boş geçmeyin !"),Display(Name = "Ürün fiyatı")]
        public decimal ProductPrice { get; set; }
        [Display(Name = "Ürün resim")]
        public string ProductImg { get; set; }
        [Required(ErrorMessage = "Lütfen {0} boş geçmeyin !"), Display(Name = "Ürün stok")]
        public int ProductStock { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public Category Category{ get; set; }
        [DefaultValue("false")]
        public bool Status { get; set; }
    }
}
