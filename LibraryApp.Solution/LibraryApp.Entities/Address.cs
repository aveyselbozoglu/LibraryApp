using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class Address : EntityBase
    {
        
        public string Street { get; set; }
        public string BuildingNo { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        public virtual User Owner { get; set; }




    }
}
