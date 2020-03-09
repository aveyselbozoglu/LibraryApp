using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Entities
{
    public class Borrow
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // ödünç alınma tarihi
        [Required]
        public DateTime BorrowedTime { get; set; }

        // ödünç verilme tarihi
        public DateTime LentTime { get; set; }

        //geri getirildi mi ?
        public bool IsLent { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}