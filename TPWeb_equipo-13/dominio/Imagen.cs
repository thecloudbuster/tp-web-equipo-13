using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
       
        public int IdArticulo { get; set; }
        public string UrlLink { get; set; }

        public override string ToString()
        {
            return UrlLink;
        }
    }
}
