using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LibraryHubFrontend.Models;
using Newtonsoft.Json;

namespace LibraryHubFrontend.Controllers
{
    public class AuthorController : Controller
    {
        private readonly HttpClient _apiService;

        public AuthorController()
        {
            var baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            _apiService = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        // GET: Authors
        public async Task<ActionResult> Index()
        {
            var response = await _apiService.GetAsync("Authors");

            if(response.IsSuccessStatusCode)
            {
                var authors = JsonConvert.DeserializeObject<List<AuthorDTO>>(await response.Content.ReadAsStringAsync());
                return View(authors);
            }

            ViewBag.Error = "No se pudo cargar la lista de autores";
            return View(new List<AuthorDTO>());
        }

        // GET: Authors/Details/
        public async Task<ActionResult> Details(int id)
        {
            var response = await _apiService.GetAsync($"Authors/{id}");

            if (response.IsSuccessStatusCode)
            {
                var author = JsonConvert.DeserializeObject<AuthorDTO>(await response.Content.ReadAsStringAsync());
                return View(author);
            }

            ViewBag.Error = "No se pudo cargar la lista de autores";
            return RedirectToAction("Index");
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
           return View();
        }

        // POST: Authors/Create
        [HttpPost]
        public async Task<ActionResult> Create(AuthorDTO authorDTO)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(authorDTO);
                }

                var content = new StringContent(JsonConvert.SerializeObject(authorDTO), Encoding.UTF8, "application/json");
                var response = await _apiService.PostAsync("Authors", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.Error = "No se pudo crear el autor";
                return View(authorDTO);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; 
                return View(authorDTO);
            }
        }

        // GET: Authors/Edit
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _apiService.GetAsync($"Authors/{id}");

            if (response.IsSuccessStatusCode)
            {
                var author = JsonConvert.DeserializeObject<AuthorDTO>(await response.Content.ReadAsStringAsync());
                return View(author);
            }

            return RedirectToAction("Index");
        }

        //POST: Authors/Edit
        [HttpPost]
        public async Task<ActionResult> Edit(AuthorDTO authorDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(authorDTO);
                }

                var content = new StringContent(JsonConvert.SerializeObject(authorDTO), Encoding.UTF8, "application/json");
                var response = await _apiService.PutAsync($"Authors/{authorDTO.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.Error = "No fue posible actualizar el autor";
                return View(authorDTO); 
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(authorDTO);
            }
        }

        // GET: Authors/Delete
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"Authors/{id}");

            if (response.IsSuccessStatusCode)
            {
                var autor = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                return View(autor);
            }
            
            return RedirectToAction("Index");
        }

        // POST: Authors/Delete
        [HttpPost]
        public async Task<ActionResult> Delete(AuthorDTO authorDTO)
        {
            try
            {
                var response = await _apiService.DeleteAsync($"Authors/{authorDTO.Id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.Error = "No se pudo eliminar el autor.";
                return View(authorDTO);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(authorDTO);
            }
        }
    }
}