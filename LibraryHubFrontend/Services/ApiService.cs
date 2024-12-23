using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LibraryHubFrontend.Services
{
    public class ApiService
    {
        private readonly string _baseURL = ConfigurationManager.AppSettings["BaseUrl"];

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Clear();    
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return await client.GetAsync(endpoint);
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent content)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return await client.PostAsync(endpoint, content);
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string endpoint, HttpContent content)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return await client.PutAsync(endpoint, content);
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return await client.DeleteAsync(endpoint);
            }
        }
    }
}