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

        public void AgregarCategoria(string descripcion)
        {
            Conexion conexion = new Conexion();
            conexion.setearConsulta("  INSERT INTO CATEGORIAS (Descripcion) VALUES (@descripcion)");
            conexion.setearParametro("descripcion", descripcion);
            conexion.ejecutarLectura();

            conexion.cerrarConexion();



        }

        public int ProximoID()
        {
            int id = 0;
            Conexion conexion = new Conexion();
            conexion.setearConsulta(" SELECT MAX(Id) +1 AS ProximoId FROM CATEGORIAS;");
            conexion.ejecutarLectura();
            conexion.Lector.Read();
            id = (int)conexion.Lector["ProximoId"];
            return id;
        }

        public List<String> ListaCategorias()
        {
            List<string> categoria = new List<string>();
            Categoria aux = new Categoria();
            Conexion datos = new Conexion();
            datos.setearConsulta("select Descripcion from CATEGORIAS");
            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {

                aux.Descripcion = (string)datos.Lector["Descripcion"];

               categoria.Add(aux.Descripcion.ToUpper());
            }


            return categoria;
        }


        public void ModificarCategoria(int id, string des)
        {
            Conexion datos = new Conexion();
            datos.setearConsulta("update CATEGORIAS set Descripcion = @descripcion where id = @id");
            datos.setearParametro("descripcion", des);
            datos.setearParametro("id", id);
            datos.ejecutarLectura();
            datos.cerrarConexion();
        }

        public void EliminarCategoria(int id)
        {
            Conexion datos = new Conexion();

            try
            {

                datos.setearConsulta("delete from CATEGORIAS where ID = @id ");
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

    }
}
