using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Models.Paginador
{
    public class Paginador<T> where T: class
    {
        public int PaginaActual { get; set; }
        public int RegistroPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public IEnumerable<T> Resultado { get; set; }
        public string BusquedaActual { get; set; }
        public bool Buscado { get; set; }
    }
}
