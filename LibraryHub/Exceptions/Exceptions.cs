using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryHub.Exceptions
{
    public class MaxLimitBooksException : Exception
    {
        public MaxLimitBooksException()
            : base("No es posible registrar el libro, se alcanzó el máximo permitido.") { }
    }
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
            : base("Entidad no encontrada.") { }

        public EntityNotFoundException(string message) : base(message) { }
    }

    public class DuplicateAuthorExeption : Exception
    {
        public DuplicateAuthorExeption()
            : base("El autor ya está registrado.") { }
    }
}