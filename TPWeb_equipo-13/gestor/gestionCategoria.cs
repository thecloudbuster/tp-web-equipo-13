using conexion;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace gestor
{
    public class gestionCategoria
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            Conexion acceso = new Conexion();
            try
            {
                acceso.setearConsulta("select Id, Descripcion from Categorias");
                acceso.ejecutarLectura();
                while (acceso.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)acceso.Lector["Id"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
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
    }
}
