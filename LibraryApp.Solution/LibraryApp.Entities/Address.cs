using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class Address : EntityBase
    {

        [Display(Name = "Sokak"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(100, ErrorMessage = "{0} 100 karakterden fazla olamaz")]
        public string Street { get; set; }
        [Display(Name = "Bina No"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(10, ErrorMessage = "{0} 10 karakterden fazla olamaz")]
        public string BuildingNo { get; set; }
        [Display(Name = "İlçe"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(50, ErrorMessage = "{0} 50 karakterden fazla olamaz")]
        public string District { get; set; }
        [Display(Name = "İl"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(50, ErrorMessage = "{0} 50 karakterden fazla olamaz")]
        public string City { get; set; }


        // UserId column relationship with User table
        [ForeignKey("Owner")]
        public int UserId { get; set; }

        public virtual User Owner { get; set; }

        




    }
}
