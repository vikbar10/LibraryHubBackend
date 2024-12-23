using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryHub.DTOs;
using LibraryHub.Entities;
using LibraryHub.Exceptions;
using LibraryHub.Interfaces;
using LibraryHub.Models.Entities;

namespace LibraryHub.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            AppSetting maxBooksAllowedConfig = _context.appSettings.FirstOrDefault(x => x.SettingName == "MaxBooksAllowed");

            if (maxBooksAllowedConfig == null) 
            {
                throw new Exception("La configuraciónde cantidad máxima de libros no está definida.");
            }

            int maxBooksAllowed = int.Parse(maxBooksAllowedConfig.SettingKey);

            int totalBooks = _context.Books.Where(x => x.IdAuthor == book.IdAuthor).Count();

            if (totalBooks == maxBooksAllowed)
            {
                throw new Exception("No es posible registrar el libro. Se alcanzó el máximo permitido");
            }

            bool exitstAuthor = _context.Authors.Any(x => x.Id == book.IdAuthor);

            if (!exitstAuthor)
            {
                throw new Exception("El autor no está registrado"); 
            }

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book book = _context.Books.Find(id);

            if (book == null)
            {
                throw new EntityNotFoundException("El libro no fue encontrado");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public void UpdateBook(Book book)
        {
            Book existBook = _context.Books.Find(book.Id);

            if (existBook != null)
            {
                existBook.Title = book.Title;
                existBook.ReleaseYear = book.ReleaseYear;
                existBook.Author = book.Author;
                existBook.BookGenre = book.BookGenre;
                existBook.PagesCount = book.PagesCount;
                _context.SaveChanges();
            }
        }
    }
}