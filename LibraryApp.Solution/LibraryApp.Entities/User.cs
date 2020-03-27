using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities
{
    public class User : EntityBase
    {

        [Display(Name = "Ad"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string Name { get; set; }


        [Display(Name = "Soyad"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string Username { get; set; }

        [Display(Name = "E Posta"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string Email { get; set; }

        [Display(Name = "Şifre"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(100, ErrorMessage = "{0} 100 karakterden fazla olamaz")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public string ProfileImageFileName { get; set; }

        //public string PhoneNumber { get; set; }

        public virtual List<Borrow> Borrows { get; set; }

        //public Address Address { get; set; }

        public User()
        {
            Borrows = new List<Borrow>();
        }
    }
}