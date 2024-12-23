using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryHubFrontend.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public int ReleaseYear { get; set; }
        public string BookGenre { get; set; }
        public int PagesCount { get; set; }
        public string AuthorName { get; set; }
    }
}