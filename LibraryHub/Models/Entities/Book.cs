using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryHub.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public string BookGenre { get; set; }

        [Required]
        public int PagesCount { get; set; }

        [Required]
        public int IdAuthor { get; set; }

        [ForeignKey("IdAuthor")]
        public virtual Author Author { get; set; }
    }
}