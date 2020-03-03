﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class Book : EntityBase
    {
        [Required,StringLength(70)]
        public string Name { get; set; }
        [Required,StringLength(250)]
        public string Summary { get; set; }
        [Required,StringLength(70)]
        public string Author { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required,StringLength(150)]
        public string Isbn { get; set; }
        [Required,StringLength(20)]
        public string Language { get; set; }

        public virtual Category Category { get; set; }

        public List<Borrow> Borrows { get; set; }

        

    }
}