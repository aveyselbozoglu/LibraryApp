using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities.ModelViews
{
    public class LoginViewModel
    {
        [Display(Name = "E Posta"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string Email { get; set; }

        [Display(Name = "Şifre"),
         Required(ErrorMessage = "{0} boş geçilemez"),
         StringLength(100)]
        public string Password { get; set; }
    }
}
