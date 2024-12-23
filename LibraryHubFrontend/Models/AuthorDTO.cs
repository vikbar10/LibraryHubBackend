using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryHubFrontend.Models
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }    
        public DateTime BirthDay { get; set; }
        public string BirthCity { get; set; }
        public string Email { get; set; }
    }
}