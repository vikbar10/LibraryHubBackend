using System.Web.Http;
using LibraryHub.Interfaces;
using LibraryHub.Services;
using Unity;
using Unity.WebApi;

namespace LibraryHub
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<IBookService, BookService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}