using conexion;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor
{
    public class gestionItem
    {
        public itemCarrito copiarArticulo(Articulo art, int cant)
        {
            itemCarrito item = new itemCarrito();
            Marca auxM = new Marca();
            Categoria auxC = new Categoria();
            item.Id = art.Id;
            item.Codigo = art.Codigo;
            item.Nombre = art.Nombre;
            item.Descripcion = art.Descripcion;
            auxM.IdMarca = art.Marca.IdMarca;
            auxM.Descripcion = art.Marca.Descripcion;
            item.Marca = auxM;
            auxC.IdCategoria = art.Categoria.IdCategoria;
            auxC.Descripcion = art.Categoria.Descripcion;
            item.Categoria = auxC;
            item.Precio = art.Precio;
            item.imagenes = art.imagenes;
            item.Cantidad = cant;

            return item;
        }
    }
}
