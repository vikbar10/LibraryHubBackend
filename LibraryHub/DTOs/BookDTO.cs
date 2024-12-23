using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryHub.DTOs
{
    public class BookDTO
    {
        public string TitleDTO { get; set; }
        public int ReleaseYearDTO { get; set; }
        public string BookGenreDTO { get; set; }
        public int PagesCountDTO { get; set; }
        public int IdAuthorDTO { get; set; }
    }
}