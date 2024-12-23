using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LibraryHubFrontend.Models;
using LibraryHubFrontend.Services;
using Newtonsoft.Json;

namespace LibraryHubFrontend.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApiService _apiService = new ApiService();

        public async Task<ActionResult> Index()
        {
            var response = await _apiService.GetAsync("Books");

            if (response.IsSuccessStatusCode)
            {
                var books = JsonConvert.DeserializeObject<List<BookDTO>>(await response.Content.ReadAsStringAsync());
                return View(books);
            }

            ViewBag.Error = "No se pudieron cargar los libros";
            return View(new List<BookDTO>());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(BookDTO bookDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(bookDTO), Encoding.UTF8, "application/Json");
            var response = await _apiService.PostAsync("Books", content);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "No se pudo crear el libro";
            return View(bookDTO);
        }

        public async Task<ActionResult> Edit(int id)
        {            
            var response = await _apiService.GetAsync($"Books/{id}");

            if (response.IsSuccessStatusCode)
            {
                var book = JsonConvert.DeserializeObject<BookDTO>(await response.Content.ReadAsStringAsync());
                return View(book);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<ActionResult> Edit(BookDTO bookDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(bookDTO), Encoding.UTF8, "application/Json");
            var response = await _apiService.PutAsync($"Books/{bookDTO.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "No se pudo actualizar el libro";
            return View(bookDTO);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"Books/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "No se pudo eliminar el libro";
            return RedirectToAction("Index");
        }
    }
}