using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class User : EntityBase
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string ProfileImageFileName { get; set; }

        //public string PhoneNumber { get; set; }



        public List<Borrow> Borrows { get; set; }
        public Address Address { get; set; }

    }
}
