using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities.ModelViews
{
    public class BookViewModel
    {
        [Display(Name = "Kitap Adı"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(70, ErrorMessage = "{0} 75 karakterden fazla olamaz")]
        public string Name { get; set; }

        [Display(Name = "Özet"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(250, ErrorMessage = "{0} 250 karakterden fazla olamaz")]
        public string Summary { get; set; }

        [Display(Name = "Yazarı"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(70, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string Author { get; set; }

        [Display(Name = "Yayın Tarihi"),
         Required(ErrorMessage = "{0}  boş geçilemez")]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Sayfa sayısı"),
         Required(ErrorMessage = "{0}  boş geçilemez")]
        public int PageCount { get; set; }

        [Display(Name = "Isbn"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(150, ErrorMessage = "{0} 150 karakterden fazla olamaz")]
        public string Isbn { get; set; }

        [Display(Name = "Dil"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(20, ErrorMessage = "{0} 20 karakterden fazla olamaz")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Kategori seçmek zorundasınız..")]
        public int Category{ get; set; }
    }
}