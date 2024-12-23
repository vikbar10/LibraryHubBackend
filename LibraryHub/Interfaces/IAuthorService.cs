using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryHub.Entities;

namespace LibraryHub.Interfaces
{
    public interface IAuthorService
    {
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);   
        void DeleteAuthor(int id);
        Author GetAuthorById(int id);
        IEnumerable<Author> GetAllAuthors();
    }
}
