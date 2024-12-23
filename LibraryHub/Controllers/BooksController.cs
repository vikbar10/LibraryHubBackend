using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using System.Web.Services.Description;
using LibraryHub.DTOs;
using LibraryHub.Entities;
using LibraryHub.Exceptions;
using LibraryHub.Interfaces;
using LibraryHub.Services;

namespace LibraryHub.Controllers
{
    [System.Web.Http.RoutePrefix("api/Books")]
    public class BooksController : ApiController
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Obtiene todos los libros registrados
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        public IHttpActionResult GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        /// <summary>
        /// Obtiene un libro a través de su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{id:int}")]
        public IHttpActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        /// <summary>
        /// Agrega un nuevo libro
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("")]
        public IHttpActionResult AddBook(BookDTO bookDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);                   
                }

                var book = new Book
                {
                    Title = bookDTO.TitleDTO,
                    ReleaseYear = bookDTO.ReleaseYearDTO,
                    BookGenre = bookDTO.BookGenreDTO,
                    PagesCount = bookDTO.PagesCountDTO,                    
                    IdAuthor = bookDTO.IdAuthorDTO                    
                };

                _bookService.AddBook(book);

                return Ok(new { Message = "Libro guardado con éxito!" });
            }
            catch (MaxLimitBooksException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un libro
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("{id:int}")]
        public IHttpActionResult UpdateBook(int id, BookDTO bookDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var book = new Book
                {
                    Title = bookDTO.TitleDTO,
                    ReleaseYear = bookDTO.ReleaseYearDTO,
                    BookGenre = bookDTO.BookGenreDTO,
                    PagesCount = bookDTO.PagesCountDTO,
                    IdAuthor = bookDTO.IdAuthorDTO,
                };
                _bookService.AddBook(book);

                return Ok(new { Message = "Libro actualizado exitosamente" });
            }
            catch (EntityNotFoundException ex)
            {
                return Content(System.Net.HttpStatusCode.NotFound, new { Error = ex.Message});
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Elimina un libro
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("{id:int}")]
        public IHttpActionResult DeleteBook(int id)
        {
            try
            {
                _bookService.DeleteBook(id);
                return Ok(new { Message = "Libro eliminado exitosamente" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
        }
    }
}