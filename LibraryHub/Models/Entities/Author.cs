using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryHub.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string BirthCity { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}