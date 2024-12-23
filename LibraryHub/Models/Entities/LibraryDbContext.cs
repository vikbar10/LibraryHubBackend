using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LibraryHub.Entities;

namespace LibraryHub.Models.Entities
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("ConnectionString") 
        {
            //this.Configuration.ProxyCreationEnabled = false;
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AppSetting> appSettings { get; set; }
    }
}