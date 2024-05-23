using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using conexion;
using System.Data.SqlTypes;


namespace gestor
{
    public class gestionMarca
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            Conexion acceso = new Conexion();
            try
            {
                acceso.setearConsulta("select Id, Descripcion from Marcas");
                acceso.ejecutarLectura();
                while (acceso.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)acceso.Lector["Id"];
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
