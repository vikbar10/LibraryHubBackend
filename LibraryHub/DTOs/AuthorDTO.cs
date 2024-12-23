using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryHub.DTOs
{
    public class AuthorDTO
    {
        public string FullNameDTO { get; set; }
        public DateTime BirthdayDTO { get; set; }
        public string BirthCityDTO { get; set; }
        public string EmailDTO { get; set; }
    }
}