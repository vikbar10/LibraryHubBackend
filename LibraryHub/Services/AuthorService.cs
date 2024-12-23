using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryHub.DTOs;
using LibraryHub.Entities;
using LibraryHub.Interfaces;
using LibraryHub.Models.Entities;

namespace LibraryHub.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryDbContext _context;

        public AuthorService(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            Author author = _context.Authors.Find(id);

            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void UpdateAuthor(Author author)
        {
            Author exitstAuthor = _context.Authors.Find(author.Id);

            if (exitstAuthor != null)
            {
                exitstAuthor.FullName = author.FullName;
                exitstAuthor.BirthCity = author.BirthCity;
                exitstAuthor.Birthday = author.Birthday;
                exitstAuthor.Email = author.Email;
                _context.SaveChanges();
            }
        }
    }
}