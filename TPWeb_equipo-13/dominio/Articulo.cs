using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace dominio
{
    public class Articulo
    {
      //  [DisplayName("Número")]
        public int Id { get; set; }
     //   [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
     //   [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string Marca { get; set; }
       // [DisplayName("Categoría")]
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public List<string> imagenes { get; set; }

       // public Imagen Imagen { get; set; }
    }
}
