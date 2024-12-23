using System.Collections.Generic;
using LibraryHub.Entities;

namespace LibraryHub.Interfaces
{
    public interface IBookService
    {
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();
    }
}
