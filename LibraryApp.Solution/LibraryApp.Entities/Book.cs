using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities
{
    public class Book : EntityBase
    {
        [Display(Name = "Kitap Adı"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(70, ErrorMessage = "{0} 70 karakterden fazla olamaz")]
        public string Name { get; set; }

        [Display(Name = "Özet"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(250, ErrorMessage = "{0} 70 karakterden fazla olamaz")]
        public string Summary { get; set; }

        [Display(Name = "Yazarı"),
         Required(ErrorMessage = "{0} boş geçilemez"),
         StringLength(70, ErrorMessage = "{0} 70 karakterden fazla olamaz")]
        public string Author { get; set; }

        [Display(Name = "Yayın Tarihi"),
         Required(ErrorMessage = "{0}  boş geçilemez")]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Sayfa Sayısı"),
         Required(ErrorMessage = "{0}  boş geçilemez")]
        public int PageCount { get; set; }

        [Display(Name = "Müsait"),
         Required(ErrorMessage = "{0}  boş geçilemez")]
        public bool IsAvailable { get; set; }

        [Display(Name = "ISBN"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(150, ErrorMessage = "{0} 70 karakterden fazla olamaz")]
        public string Isbn { get; set; }

        [Display(Name = "Dil"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(20, ErrorMessage = "{0} 70 karakterden fazla olamaz")]
        public string Language { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Borrow> Borrows { get; set; }
    }
}