using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities.ModelViews
{
    public class RegisterViewModel
    {
        [Display(Name = "Ad"),
         Required(ErrorMessage = "{0} boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string Name { get; set; }

        [Display(Name = "Soyad"),
        Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı"),
        Required(ErrorMessage = "{0} boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} adı 25 karakterden fazla olamaz")]
        public string Username { get; set; }

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