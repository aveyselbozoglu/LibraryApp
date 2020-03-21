using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities.ModelViews
{
    public class AddressViewModel
    {
        [Display(Name = "Sokak"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(100, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string Street { get; set; }

        [Display(Name = "Bina No"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(10, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string BuildingNo { get; set; }

        [Display(Name = "İlçe"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(50, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string District { get; set; }

        [Display(Name = "İl"),
         Required(ErrorMessage = "{0}  boş geçilemez"),
         StringLength(50, ErrorMessage = "{0} 25 karakterden fazla olamaz")]
        public string City { get; set; }
    }
}