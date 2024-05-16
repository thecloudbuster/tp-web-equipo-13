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
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
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
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
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

        public void agregar(Articulo art)
        {
            try
            {
                Conexion datos = new Conexion();
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)" +
                    " VALUES ('" + art.Codigo + "', '" + art.Nombre + "', '" + art.Descripcion + "', @marcaId, @categoriaId, @precio)");
                datos.setearParametro("@marcaId", art.Marca.IdMarca);
                datos.setearParametro("@categoriaId", art.Categoria.IdCategoria);
                datos.setearParametro("@precio", art.Precio);
                datos.ejecutarAccion();
                datos.cerrarConexion();
                datos = new Conexion();
                art.Id = datos.ultimoId();
                datos.cerrarConexion();
                foreach (string imagen in art.imagenes)
                {
                    datos = new Conexion();
                    datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenURL) VALUES (" + art.Id + ", '" + imagen + "')");
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void modificar(Articulo art)
        {
            Conexion acceso = new Conexion();
            try
            {
                acceso.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, Precio = @idprecio where Id = @id");
                // acceso.setearConsulta("update IMAGENES set ImagenUrl = @imagenurl where IdArticulo = @id"); // hay que revisar esto
                acceso.setearParametro("@codigo", art.Codigo);
                acceso.setearParametro("@nombre", art.Nombre);
                acceso.setearParametro("@descripcion", art.Descripcion);
                acceso.setearParametro("@idmarca", art.Marca.IdMarca);
                acceso.setearParametro("@idcategoria", art.Categoria.IdCategoria);
                acceso.setearParametro("@idprecio", art.Precio);
                //acceso.setearParametro("@imagenurl", art.Imagen.UrlLink);// hay que revisar esto
                acceso.setearParametro("@id", art.Id);
                acceso.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public void EliminarArticulo(int id)
        {
            Conexion datos = new Conexion();

            try
            {

                datos.setearConsulta("delete from ARTICULOS where ID = @id ");
                datos.setearParametro("id", id);
                datos.ejecutarLectura();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

            finally
            {

                datos.cerrarConexion();

            }

        }



        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            Conexion datos = new Conexion();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                string consulta = @"select distinct(a.Id) as Id, Codigo, Nombre, a.Descripcion as Descripcion, case when m.Descripcion is null then '' else m.Descripcion end as Marca, case when c.Descripcion is null then '' else c.Descripcion end as Categoria, Precio, case when i.ImagenUrl is null then '' else i.ImagenUrl end as 'Url' from Articulos a left join Marcas m on m.Id=a.IdMarca left join Categorias c on c.Id=a.IdCategoria left join Imagenes i on a.id=i.IdArticulo ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += " where Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += " where Precio < " + filtro;
                            break;
                        default:
                            consulta += " where Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " where Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += " where Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " where Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " where m.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += " where m.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " where m.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " where c.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += " where c.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " where c.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta( consulta );
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Imagen = new Imagen();
                    if (!(datos.Lector["Url"] is DBNull))
                        aux.Imagen.UrlLink = (string)datos.Lector["Url"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
