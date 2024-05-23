using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using dominio;
using conexion;
using System.Data.SqlTypes;

namespace gestor
{
    public class gestionArticulo
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            Conexion datos = new Conexion();

            try
            {
                datos.setearConsulta("SELECT A.Id, Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdCategoria, A.IdMarca, M.Descripcion Marca, C.Id IdCategoria, C.Descripcion Categoria " +
                   "FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Categoria = new Categoria();

                    if (!(datos.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    }
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    else
                    {
                        aux.Categoria.Descripcion = "Sin Categoria";
                    }

                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                    {
                        aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    }
                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marca.Descripcion = "Sin Marca";
                    }

                    lista.Add(aux);
                }
                datos.cerrarConexion();

                datos = new Conexion();
                datos.setearConsulta("SELECT IdArticulo, ImagenURL FROM IMAGENES");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    foreach (Articulo item in lista)
                    {
                        if (item.Id == (int)datos.Lector["IdArticulo"])
                        {
                            if (item.imagenes == null)
                            {
                                item.imagenes = new List<string>();
                            }
                            item.imagenes.Add((string)datos.Lector["ImagenURL"]);
                        }
                    }
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
