using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class Address : EntityBase
    {
        [Required,StringLength(100)]
        public string Street { get; set; }
        [Required,StringLength(10)]
        public string BuildingNo { get; set; }
        [Required,StringLength(50)]
        public string District { get; set; }
        [Required,StringLength(50)]
        public string City { get; set; }

        [Required]
        public virtual User Owner { get; set; }




    }
}
