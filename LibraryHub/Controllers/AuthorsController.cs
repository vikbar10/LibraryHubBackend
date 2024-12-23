using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using LibraryHub.DTOs;
using LibraryHub.Entities;
using LibraryHub.Exceptions;
using LibraryHub.Interfaces;
using LibraryHub.Services;

namespace LibraryHub.Controllers
{
    [System.Web.Http.RoutePrefix("api/Authors")]
    public class AuthorsController : ApiController
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Obtiene todos los autores registrados
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        public IHttpActionResult GetAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        /// <summary>
        /// Obtiene un autor a través de su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{id:int}")]
        public IHttpActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        /// <summary>
        /// Agrega un nuevo autor
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("")]
        public IHttpActionResult AddAuthor(AuthorDTO authorDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var author = new Author
                {
                    FullName = authorDTO.FullNameDTO,
                    BirthCity = authorDTO.BirthCityDTO,
                    Birthday = authorDTO.BirthdayDTO,
                    Email = authorDTO.EmailDTO

                };

                _authorService.AddAuthor(author);

                return Ok(new { Message = "Autor guardado con éxito!" });
            }
            catch (DuplicateAuthorExeption ex)
            {
                return BadRequest(ex.Message);
            }            
        }


        /// <summary>
        /// Actualiza un autor
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("{id:int}")]
        public IHttpActionResult UpdateAuthor(int id, AuthorDTO authorDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var author = new Author
                {
                    Id = id,
                    FullName = authorDTO.FullNameDTO,   
                    BirthCity = authorDTO.BirthCityDTO,
                    Birthday = authorDTO.BirthdayDTO,
                    Email = authorDTO.EmailDTO
                };

                _authorService.UpdateAuthor(author);

                return Ok(new { Message = "Autor actualizado exitosamente"});
            }
            catch (EntityNotFoundException ex)
            {
                return Content(System.Net.HttpStatusCode.NotFound, new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Elimina un autor
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("{id:int}")]
        public IHttpActionResult DeleteAuthor(int id)
        {
            try
            {
                _authorService.DeleteAuthor(id);
                return Ok(new { Message = "Autor eliminado exitosamente" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
        }
    }
}