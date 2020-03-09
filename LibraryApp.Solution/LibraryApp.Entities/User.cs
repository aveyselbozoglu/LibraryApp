using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities
{
    public class User : EntityBase
    {
        [Required, StringLength(25)]
        public string Name { get; set; }

        [Required, StringLength(25)]
        public string Surname { get; set; }

        [Required, StringLength(25)]
        public string Username { get; set; }

        [Required, StringLength(25)]
        public string Email { get; set; }

        [Required, StringLength(100)]
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