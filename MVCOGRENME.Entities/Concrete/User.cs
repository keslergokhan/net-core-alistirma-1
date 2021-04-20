using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCOGRENME.Core.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace MVCOGRENME.Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserID { get; set; }
        
        [Required(ErrorMessage = "Lütfen {0} boş bırakmayınız !"),Column(TypeName = "varchar"),StringLength(50,ErrorMessage =" En fazla {1} karakter !"),Display(Name = "Kullanıcı Ad")]
        public string UserName { get; set; }

        [Display(Name = "Kullanıcı resim")]
        public string UserImg { get; set; }

        [Required(ErrorMessage = "Lütfen {0} boş bırakmayınız !"), Column(TypeName = "varchar"), StringLength(50, ErrorMessage = " En fazla {1} karakter !"), Display(Name = "Kullanıcı Soyadı")]
        public string UserSurName { get; set; }

        [Required(ErrorMessage = "Lütfen {0} boş bırakmayınız !"),DataType(DataType.EmailAddress), Column(TypeName = "varchar"), StringLength(80, ErrorMessage = " En fazla {1} karakter !"), Display(Name = "Kullanıcı Mail")]
        public string UserMail { get; set; }

        [Required(ErrorMessage = "Lütfen {0} boş bırakmayınız !"),DataType(DataType.Password),StringLength(50,ErrorMessage = "En fazla {1} karakter"),Display(Name ="Kullanıcı Şifre")]
        public string UserPassword { get; set; }

        [Compare(nameof(UserPassword),ErrorMessage = "Girilen şifre eşleşmiyor !"), StringLength(50, ErrorMessage = "En fazla {1} karakter"),Display(Name = "Şifre kontrol")]
        public string UserPassword2 { get; set; }

        [DefaultValue("false")]
        public bool Status { get; set; }
    }
}
